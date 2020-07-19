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
        private bool _startOnAwake;
        [SerializeField]
        private float _delay = 1.2f;
        private int _currentSlide = -1;
        private List<BaseTutorialSlide> _tutorialSlides;
        private InputSystem _inputSystem;

        private void Start()
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
                _inputSystem.EnableInputs(true,true,true,true);
        }

        public void NextSlide()
        {
            StartCoroutine(NextSlideCoroutine());
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