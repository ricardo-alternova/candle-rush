using UnityEngine;
using UnityEngine.SceneManagement;

namespace GJam2020.Level.UI
{
    public class OptionsMenu : MonoBehaviour
    {
        private bool _soundEnable = true;

        private void Awake()
        {
            //gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
#if UNITY_ANDROID
            if (Input.GetKeyDown(KeyCode.Escape))
                Close();
#endif
        }

        public void Close()
        {
            gameObject.SetActive(false);
            GameManager.Get.IsPlaying = true;
        }

        public void EnableSound()
        {
            if(_soundEnable)
            {
                _soundEnable = false;
            }
            else
            {
                _soundEnable = true;
            }
        }

        public void GoHome()
        {
            SceneManager.LoadScene(GameManager.MAIN_MENU_NAME);
        }
    }
}