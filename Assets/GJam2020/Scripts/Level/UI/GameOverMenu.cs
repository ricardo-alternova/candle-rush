using GGJ2020.Levels;
using GJam2020.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GJam2020.Level.UI
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject _optionsMenu;
        private static GameOverMenu _instance;

        public static GameOverMenu Get()
        {
            return _instance;
        }

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
        }
        
        public void CloseMenu()
        {
            gameObject.SetActive(false);

        }

        public void Restore()
        {
            Time.timeScale = 1;

            SoundManager.Get().FxPlayer.Restart();
            SoundManager.Get().Play();
            GameManager.Get.Restore();
            GameOverCtrl.Get().Reset();
            LevelManager.Get.ResetGame();
            gameObject.SetActive(false);
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

        public void GoHome()
        {
            Time.timeScale = 1;

            SceneManager.LoadScene(GameManager.MAIN_MENU_NAME);
        }
    }
}