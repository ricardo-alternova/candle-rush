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
        [SerializeField]
        private GameObject gameEndPanel;
        [SerializeField]
        private UnityEngine.UI.Text totalStarsText;

        public void PlayStars(int stars)
        {
            StartCoroutine(ShowStars(stars));
        }

        public void NextLevel()
        {
            GameManager.Get.currentLevel = LevelManager.Get.NextLevel;
            if (GameManager.Get.currentLevel == null)
                ShowGameEnd();
            else
                GameManager.Get.NewLevelComplete(LevelManager.Get.LevelNumber, LevelManager.Get.Stars, GameManager.GAMEPLAY_NAME);
        }

        public void GoHome()
        {
            SceneManager.LoadScene(GameManager.MAIN_MENU_NAME);
        }

        // Saves the last level's result and returns to the main menu, as reaching the end did before the end screen.
        public void FinishGame()
        {
            GameManager.Get.NewLevelComplete(LevelManager.Get.LevelNumber, LevelManager.Get.Stars, GameManager.MAIN_MENU_NAME);
        }

        private void ShowGameEnd()
        {
            int level = LevelManager.Get.LevelNumber;
            int savedTotal = GameManager.Get.TotalStars;
            int savedLevelScore = GameManager.Get.GetLevelScore(level);
            int total = savedTotal - savedLevelScore + Mathf.Max(savedLevelScore, LevelManager.Get.Stars);
            totalStarsText.text = total.ToString();
            gameEndPanel.SetActive(true);
        }
        
        private IEnumerator ShowStars(int stars)
        {
            SoundManager.Get().FxPlayer.Restart();
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