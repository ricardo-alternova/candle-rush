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
            print("restore");
            GameManager.Get.Restore();
            gameObject.SetActive(false);
        }

        public void GoHome()
        {
            SceneManager.LoadScene(GameManager.MAIN_MENU_NAME);
        }
    }
}