using GJam2020.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GJam2020.Level.UI
{
    public class WinMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        public void NextLevel()
        {
            GameManager.Get.currentLevel = LevelManager.Get.NextLevel;
            if (GameManager.Get.currentLevel == null)
                GameManager.Get.NewLevelComplete(LevelManager.Get.LevelNumber, LevelManager.Get.Score, GameManager.MAIN_MENU_NAME);
            else
                GameManager.Get.NewLevelComplete(LevelManager.Get.LevelNumber, LevelManager.Get.Score, GameManager.GAMEPLAY_NAME);
        }

        public void GoHome()
        {
            SceneManager.LoadScene(GameManager.MAIN_MENU_NAME);
        }
    }
}