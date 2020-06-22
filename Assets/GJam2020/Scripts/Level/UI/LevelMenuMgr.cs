using GJam2020.Core;
using UnityEngine;

namespace GJam2020.Level.UI
{
    public class LevelMenuMgr : MonoBehaviour
    {
        [SerializeField]
        private GameObject _optionsButton;
        [SerializeField]
        private GameObject _optionsMenu;
        [SerializeField]
        private GameObject _pauseMenu;
        [SerializeField]
        private GameObject _gameOverMenu;
        [SerializeField]
        private GameObject _winMenu;

        private static LevelMenuMgr _instance;

        private void Awake()
        {
            _instance = this;
        }

        public static LevelMenuMgr Get() { return _instance; }

        public void OpenOptions()
        {
            GameManager.Get.IsPlaying = false;
            _optionsButton.SetActive(false);
            _optionsMenu.SetActive(true);
        }
        public void OpenGameOver()
        {
            GameManager.Get.IsPlaying = false;
            _gameOverMenu.SetActive(true);
        }
        public void OpenWin()
        {
            GameManager.Get.IsPlaying = false;
            _winMenu.SetActive(true);
        }
        public void OpenPause()
        {
            SoundManager.Get().Pause();
            GameManager.Get.IsPlaying = false;
            _pauseMenu.SetActive(true);
        }

        public void CloseOptions()
        {
            _optionsButton.SetActive(true);
            GameManager.Get.IsPlaying = true;
        }
    }
}