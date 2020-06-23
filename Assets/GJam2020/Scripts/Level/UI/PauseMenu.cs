using GJam2020.Core;
using UnityEngine;

namespace GJam2020.Level.UI
{
    public class PauseMenu : BaseLevelMenu
    {
        [SerializeField]
        private AudioClip _playAudioClip;

        private void OnEnable()
        {
            Time.timeScale = 0;
        }

        public void Play()
        {
            Time.timeScale = 1;
            SoundManager.Get().Play();
            _audioSourcePlayer.Play(_playAudioClip);
            gameObject.SetActive(false);
            GameManager.Get.IsPlaying = true;
        }
    }
}