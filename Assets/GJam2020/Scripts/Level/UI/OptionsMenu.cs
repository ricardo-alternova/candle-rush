using GJam2020.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GJam2020.Level.UI
{
    public class OptionsMenu : MonoBehaviour
    {
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
            SoundManager.Get().Play();
        }

        
    }
}