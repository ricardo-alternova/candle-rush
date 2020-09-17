using GJam2020.Core;
using UnityEngine;

namespace GJam2020.Level.UI
{
    public class LevelMenuMgr : MonoBehaviour
    {
        [SerializeField]
        private GameObject _optionsButton;
        [SerializeField]
        private GameObject _pauseButton;
        [SerializeField]
        private GameObject _optionsMenu;
        [SerializeField]
        private GameObject _pauseMenu;
        [SerializeField]
        private GameObject _gameOverMenu;
        [SerializeField]
        private GameObject _winMenu;
        [SerializeField]
        private GameObject _audioPanel;

        private static LevelMenuMgr _instance;

        private GameObject _panelActivatorLevels;

        private void Awake()
        {
            _instance = this;
        }

        public static LevelMenuMgr Get() { return _instance; }

        
        public void OpenGameOver()
        {
            SoundManager.Get().FxPlayer.Restart();
            GameManager.Get.IsPlaying = false;
            _gameOverMenu.SetActive(true);
            _pauseButton.SetActive(false);
        }

        public void OpenWin(int stars)
        {
            _optionsButton.SetActive(false);
            _pauseButton.SetActive(false);

            GameManager.Get.IsPlaying = false;
            _winMenu.SetActive(true);
            _winMenu.GetComponent<WinMenu>().PlayStars(stars);
        }

        public void OpenPause()
        {
            SoundManager.Get().Pause();
            GameManager.Get.IsPlaying = false;
            _pauseMenu.SetActive(true);
        }


        public void OpenOptions(GameObject panelActivator)
        {
            Time.timeScale = 1;
            GameManager.Get.IsPlaying = false;
            SoundManager.Get().Pause(true, false, false);
            _optionsMenu.SetActive(true);
            panelActivator.SetActive(false);
            _panelActivatorLevels = panelActivator;
        }

        public void CloseOptions()
        {
            Time.timeScale = 0;
            _optionsMenu.SetActive(false);
            if (_panelActivatorLevels != null)
            {
                _panelActivatorLevels.SetActive(true);
            }
        }

        public void OpenAudioPanel(GameObject panelActivator)
        {
            panelActivator.SetActive(false);
            _audioPanel.SetActive(true);
            _panelActivatorLevels = panelActivator;
        }
        public void CloaseAudioPanel()
        {
            _audioPanel.SetActive(false);
            if (_panelActivatorLevels != null)
            {
                _panelActivatorLevels.SetActive(true);
            }
        }
    }
}