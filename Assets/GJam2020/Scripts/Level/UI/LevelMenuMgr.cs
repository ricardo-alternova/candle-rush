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
            _optionsButton.SetActive(false);
            _optionsMenu.SetActive(true);
        }
        public void OpenGameOver()
        {
            _gameOverMenu.SetActive(true);
        }
        public void OpenWin()
        {
            _winMenu.SetActive(true);
        }
        public void OpenPause()
        {
            _pauseMenu.SetActive(true);
        }

        public void CloseOptions()
        {
            _optionsButton.SetActive(true);
        }
    }
}