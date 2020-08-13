using DG.Tweening;
using Cinemachine;
using GGJ2020.Avatar;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2020.Levels
{
    public class GameOverCtrl : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera _CMvirtualCam;
        [SerializeField]
        private GameObject _light;
        private GameObject _directionalLight;
        [SerializeField]
        private Vector3 _lightOffset;
        [SerializeField]
        private AudioClip _gameOverClip;
        [SerializeField]
        private AudioSource _FxAudioSource;
        [SerializeField]
        private Image _background;
        private static GameOverCtrl _instance;

        public static GameOverCtrl Get() { return _instance; }

        private void Awake()
        {
            _instance = this;
        }

        void Start()
        {
            _directionalLight = GameObject.Find("Directional Light");
        }

        [ContextMenu("Play")]
        public void Play()
        {
            _CMvirtualCam.Priority = 100;
            _FxAudioSource.clip = _gameOverClip;
            _directionalLight.gameObject.SetActive(false);
            _FxAudioSource.Play();
            _light.SetActive(true);
            _light.transform.position = AvatarPosition.AVATAR_POSITION + _lightOffset;

            var fadeBlackColor = new Color(0, 0, 0, 0.7f);
            _background.gameObject.SetActive(true);
            _background.DOBlendableColor(fadeBlackColor, 1);
        }

        [ContextMenu("Reset")]
        public void Reset()
        {
            _CMvirtualCam.Priority = 1;
            _FxAudioSource.Stop();
            _directionalLight.gameObject.SetActive(true);
            _light.SetActive(false);

            _background.DOBlendableColor(Color.clear, 1);
            Invoke("DisableBackground", 1);
        }

        private void DisableBackground()
        {
            _background.gameObject.SetActive(false);
        }
    }
}