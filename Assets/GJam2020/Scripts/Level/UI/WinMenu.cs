using GJam2020.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace GJam2020.Level.UI
{
    public class WinMenu : MonoBehaviour
    {

        // Start is called before the first frame update
        public Image[] Stars;
        public Sprite StarActive;
        public void SetStarsNumber(int stars)
        {
            StartCoroutine(ShowStars(stars));
        }
        
        private IEnumerator ShowStars(int stars)
        {
            for(int i = 0; i < Stars.Length; i++)
            {
                yield return new WaitForSeconds(.5f);
                if (i < stars)
                {
                    Stars[i].sprite = StarActive;
                }
            }
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
    }
}