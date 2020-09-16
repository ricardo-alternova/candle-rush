using GGJ2020.Levels;
using GJam2020.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GJam2020.Level.UI
{
    public class GameOverMenu : MonoBehaviour
    {
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
            //CloseMenu();
        }
        
        public void CloseMenu()
        {
            gameObject.SetActive(false);

        }

        public void Restore()
        {
            SoundManager.Get().FxPlayer.Restart();
            GameManager.Get.Restore();
            GameOverCtrl.Get().Reset();
            LevelManager.Get.ResetGame();
            gameObject.SetActive(false);
        }

        public void GoHome()
        {
            SceneManager.LoadScene(GameManager.MAIN_MENU_NAME);
        }
    }
}