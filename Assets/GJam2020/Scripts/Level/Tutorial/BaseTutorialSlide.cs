using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GJam2020.Game.Tutorial
{
    public class BaseTutorialSlide : MonoBehaviour
    {
        [SerializeField]
        protected float _delay = 1;

        public virtual void Hide()
        {
            var images = GetComponentsInChildren<Image>();
            foreach(var image in images)
            {
                image.DOFade(0, 0.5f);
            }
            var texts = GetComponentsInChildren<Text>();
            foreach (var text in texts)
            {
                text.DOFade(0, 0.5f);
            }
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);

            var images = GetComponentsInChildren<Image>();
            foreach (var image in images)
            {
                image.DOFade(1, 0.5f);
            }
            var texts = GetComponentsInChildren<Text>();
            foreach (var text in texts)
            {
                text.DOFade(1, 0.5f);
            }
        }

        protected void DisableGO()
        {
            gameObject.SetActive(false);
        }
    }
}