using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GJam2020.Core;

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

        // Start is called before the first frame update
        void Start()
        {
            _tutorialSlides = GetComponentsInChildren<BaseTutorialSlide>().ToList();

            foreach (var child in _tutorialSlides)
            {
                child.gameObject.SetActive(false);
            }

            if (PlayerPrefsMgr.Get().LoadInt("tutorial") != 1)
            {
                if (_startOnAwake)
                    NextSlide();
            }

        }

        public void NextSlide()
        {
            StartCoroutine(NextSlideCoroutine());
        }

        private IEnumerator NextSlideCoroutine()
        {
            if (_currentSlide >= 0)
            {
                PlayerPrefsMgr.Get().Save<int>("tutorial", 1);
                _tutorialSlides[_currentSlide].gameObject.SetActive(false);
            }

            if (_currentSlide + 1 >= _tutorialSlides.Count) yield break;

            _currentSlide++;

            yield return new WaitForSeconds(_delay);

            _tutorialSlides[_currentSlide].gameObject.SetActive(true);
        }
    }
}