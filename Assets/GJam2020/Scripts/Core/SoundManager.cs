using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GJam2020.Core
{
    public class SoundManager : MonoBehaviour
    {
        public enum SoundType { SONG, UI, FX}
        public bool IsFxEnabled = true;
        public bool IsUIEnabled = true;
        public bool IsSongEnable = true;

        [SerializeField]
        private AudioMixerGroup fxGroup;
        [SerializeField]
        private AudioMixerGroup uiGroup;
        [SerializeField]
        private AudioMixerGroup songGroup;

        [SerializeField]
        private AudioSourcePlayer fxPlayer;

        private bool _isPaused;
        private static SoundManager _instance;
        private AudioMixer audioMixer;

        public AudioSourcePlayer FxPlayer { get => fxPlayer; }

        private void Awake()
        {
            if (_instance != null)
            {
                if (_instance != this)
                    Destroy(gameObject);
            }
            else
                _instance = this;

            audioMixer = songGroup.audioMixer;
        }

        private void Start()
        {
            EnableFx(PlayerPrefsMgr.Get().LoadInt("PauseFxState") == 0 ? false : true);
            EnableUI(PlayerPrefsMgr.Get().LoadInt("PauseUIState") == 0 ? false : true);
            EnableSong(PlayerPrefsMgr.Get().LoadInt("PauseSongsState") == 0 ? false : true);
        }

        public static SoundManager Get() { return _instance; }

        public AudioMixerGroup GetMixerGroup(SoundType soundType)
        {
            switch (soundType)
            {
                case SoundType.UI:
                    return uiGroup;
                case SoundType.FX:
                    return fxGroup;
                case SoundType.SONG:
                    return songGroup;
                default:
                    Debug.Log(soundType.ToString() + " - Not Implemented");
                    return songGroup;
            }
        }

        public void EnableFx(bool enable)
        {
            IsFxEnabled = enable;
            PlayerPrefsMgr.Get().Save<int>("PauseFxState", enable ? 1 : 0);
            audioMixer.SetFloat("FXVolume", enable ? 0 : -80);
        }

        public void EnableUI(bool enable)
        {
            IsUIEnabled = enable;
            PlayerPrefsMgr.Get().Save<int>("PauseUIState", enable ? 1 : 0);
            audioMixer.SetFloat("UIVolume", enable ? 0 : -80);
        }

        public void EnableSong(bool enable)
        {
            IsSongEnable = enable;
            PlayerPrefsMgr.Get().Save<int>("PauseSongsState", enable ? 1 : 0);
            audioMixer.SetFloat("SongVolume", enable ? 0 : -80);
        }

        public void Pause()
        {
            if (_isPaused) return;
            _isPaused = true;

            if (IsSongEnable)
                audioMixer.SetFloat("SongVolume", -80);
            if (IsUIEnabled)
                audioMixer.SetFloat("UIVolume", -80);
            if (IsFxEnabled)
                audioMixer.SetFloat("FXVolume", -80);
        }

        public void Play()
        {
            if (!_isPaused) return;
            _isPaused = false;

            if (IsSongEnable)
                audioMixer.SetFloat("SongVolume", 0);
            if (IsUIEnabled)
                audioMixer.SetFloat("UIVolume", 0);
            if (IsFxEnabled)
                audioMixer.SetFloat("FXVolume", 0);
        }
    }
}