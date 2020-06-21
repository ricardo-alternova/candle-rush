using UnityEngine;

namespace GJam2020.Level.UI
{
    public class PauseMenu : MonoBehaviour
    {
        private void Awake()
        {
            
        }

        private void OnEnable()
        {
            Time.timeScale = 0;
        }

        public void Play()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            GameManager.Get.IsPlaying = true;
        }
    }
}