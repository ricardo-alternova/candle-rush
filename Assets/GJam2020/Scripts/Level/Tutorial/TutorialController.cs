using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GJam2020.Core;
using UnityEngine.Assertions;

namespace GJam2020.Game.Tutorial
{
    public class TutorialController : MonoBehaviour
    {
        [SerializeField]
        private InputType _inputType;
        [SerializeField]
        private bool _startOnAwake;
        [SerializeField]
        private float _delay = 1.2f;
        private int _currentSlide = -1;
        private List<BaseTutorialSlide> _tutorialSlides;
        private InputSystem _inputSystem;

        public enum InputType { Keyboard, Gamepad, Touch }

        private void Start()
        {
            if (!MustBeEnabled())
            {
                Debug.Log("Input Type: " + _inputType + "; Joysticks: " + Input.GetJoystickNames()[0]);
                gameObject.SetActive(false);
            }
            else
            {
                _tutorialSlides = GetComponentsInChildren<BaseTutorialSlide>().ToList();

                foreach (var child in _tutorialSlides)
                {
                    child.gameObject.SetActive(false);
                }
                _inputSystem = GameObject.Find("Systems").GetComponent<InputSystem>();

                if (PlayerPrefsMgr.Get().LoadInt("tutorial") != 1)
                {
                    if (_startOnAwake)
                    {
                        _inputSystem.EnableInputs(false, false, false, false);
                        NextSlide();
                    }
                }
                else
                    _inputSystem.EnableInputs(true, true, true, true);
            }
        }

        [ContextMenu("NextSlide")]
        public void NextSlide()
        {
            StartCoroutine(NextSlideCoroutine());
        }

        public void EnableTutorials()
        {
            var enabledState = PlayerPrefsMgr.Get().LoadInt("tutorial");
            Debug.Log("Tutorial enabled: " + (enabledState == 1).ToString());

            PlayerPrefsMgr.Get().Save<int>("tutorial", enabledState == 0
                ? 1 
                : 0);
        }

        private bool MustBeEnabled()
        {
#if UNITY_WEBGL
            bool mustBeEnabled = true;
            Debug.Log("Gamepads: " + Input.GetJoystickNames()[0]);
            if (_inputType == InputType.Touch)
                mustBeEnabled = false;

            if (_inputType == InputType.Gamepad)
            {
                if (Input.GetJoystickNames().Length == 0)
                    mustBeEnabled = false;
                else if(Input.GetJoystickNames()[0].Equals(""))
                    mustBeEnabled = false;
            }


            if (_inputType == InputType.Keyboard)
                if (Input.GetJoystickNames().Length > 0)
                    if(!Input.GetJoystickNames()[0].Equals(""))
                    mustBeEnabled = false;
#elif UNITY_TVOS
            if (_inputType == InputType.Keyboard)
                    mustBeEnabled = false;

            if (_inputType == InputType.Touch)
                mustBeEnabled = false;
#else
            if (_inputType == InputType.Touch && Input.GetJoystickNames().Length > 0)
                if (!Input.GetJoystickNames()[0].Equals(""))
                    mustBeEnabled = false;

            if (_inputType == InputType.Keyboard)
                mustBeEnabled = false;

            if (_inputType == InputType.Gamepad)
                if (Input.GetJoystickNames().Length == 0)
                    mustBeEnabled = false;
#endif
            return mustBeEnabled;
        }

        private IEnumerator NextSlideCoroutine()
        {
            _inputSystem.EnableInputs(false, false, false, false);

            if (_currentSlide >= 0)
            {
                _tutorialSlides[_currentSlide].Hide();
            }

            if (_currentSlide + 1 >= _tutorialSlides.Count)
            {
                Debug.Log("Tutorial finished");
                PlayerPrefsMgr.Get().Save<int>("tutorial", 1);
                yield return new WaitForSeconds(0.7f);

                Assert.IsNotNull(_inputSystem);
                _inputSystem.EnableInputs(true, true, true, true);

                yield break;
            }

            _currentSlide++;

            yield return new WaitForSeconds(_delay);

            _tutorialSlides[_currentSlide].Show();
        }
    }
}