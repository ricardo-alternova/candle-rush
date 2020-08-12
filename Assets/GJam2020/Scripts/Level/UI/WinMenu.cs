using GJam2020.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace GJam2020.Level.UI
{
    public class WinMenu : MonoBehaviour
    {
        [SerializeField]
        private StartAnimation[] Stars;

        public void PlayStars(int stars)
        {
            StartCoroutine(ShowStars(stars));
        }

        public void NextLevel()
        {
            GameManager.Get.currentLevel = LevelManager.Get.NextLevel;
            if (GameManager.Get.currentLevel == null)
                GameManager.Get.NewLevelComplete(LevelManager.Get.LevelNumber, LevelManager.Get.Stars, GameManager.MAIN_MENU_NAME);
            else
                GameManager.Get.NewLevelComplete(LevelManager.Get.LevelNumber, LevelManager.Get.Stars, GameManager.GAMEPLAY_NAME);
        }

        public void GoHome()
        {
            SceneManager.LoadScene(GameManager.MAIN_MENU_NAME);
        }
        
        private IEnumerator ShowStars(int stars)
        {
            foreach (var start in Stars)
                start.Show();

            for (int i = 0; i < stars; i++)
            {
                yield return new WaitForSeconds(.9f);
                Stars[i].Fill();
            }
        }
    }
}