using GJam2020.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GJam2020.Level.UI
{
    public class PauseMenu : BaseLevelMenu
    {
        [SerializeField]
        private AudioClip _playAudioClip;
        [SerializeField]
        private GameObject _optionsMenu;

        private void OnEnable()
        {
            Time.timeScale = 0;
        }

        public void Play()
        {
            Time.timeScale = 1;
            SoundManager.Get().Play();
            _audioSourcePlayer.Play(_playAudioClip);
            gameObject.SetActive(false);
            GameManager.Get.IsPlaying = true;
        }

        public void GoHome()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(GameManager.MAIN_MENU_NAME);
        }

        public void OpenLevels()
        {
            Time.timeScale = 1;

            GameManager.Get.IsPlaying = false;
            SoundManager.Get().Pause(true, false, false);
            _optionsMenu.SetActive(true);
        }

        public void CloseLevelsSelector()
        {
            Time.timeScale = 0;

            _optionsMenu.SetActive(false);
        }

        public void ResetLevel()
        {
            Time.timeScale = 1;

            GameManager.Get.ResetCurrentLevel();
        }
    }
}