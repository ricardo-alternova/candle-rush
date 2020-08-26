using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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
        private Camera mainCamera;

        public AudioSourcePlayer FxPlayer { get => fxPlayer; }

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;

            if (_instance != null)
            {
                if (_instance != this)
                    Destroy(gameObject);
            }
            else
                _instance = this;

            audioMixer = songGroup.audioMixer;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            mainCamera = Camera.main;
        }

        private void Start()
        {
            audioMixer.SetFloat("FxVolume", PlayerPrefsMgr.Get().LoadInt("FxVolume"));
            audioMixer.SetFloat("UiVolume", PlayerPrefsMgr.Get().LoadInt("UiVolume"));
            audioMixer.SetFloat("SongVolume", PlayerPrefsMgr.Get().LoadInt("SongVolume"));
        }

        private void Update()
        {
            if (mainCamera)
                fxPlayer.transform.position = mainCamera.transform.position;
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

        public int GetVolumePercent(SoundType type)
        {
            switch (type)
            {
                case SoundType.FX:
                    return (int)((PlayerPrefsMgr.Get().LoadInt("FxVolume")+80f)*1.25f);
                case SoundType.UI:
                    return (int)((PlayerPrefsMgr.Get().LoadInt("UiVolume") + 80f) * 1.25f);
                case SoundType.SONG:
                    return (int)((PlayerPrefsMgr.Get().LoadInt("SongVolume") + 80f) * 1.25f);
            }
            return 100;
        }

        public void SetVolumePercent(int percent,SoundType type)
        {
            float volume = (-80f + (percent / 1.25f));
            switch (type)
            {
                case SoundType.FX:
                    PlayerPrefsMgr.Get().Save<int>("FxVolume", (int) volume);
                    audioMixer.SetFloat("FxVolume",volume);
                    break;
                case SoundType.UI:
                    PlayerPrefsMgr.Get().Save<int>("UiVolume", (int)volume);
                    audioMixer.SetFloat("UiVolume", volume);
                    break;
                case SoundType.SONG:
                    PlayerPrefsMgr.Get().Save<int>("SongVolume", (int)volume);
                    audioMixer.SetFloat("SongVolume", volume);
                    break;
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
            //if (_isPaused) return;
            //_isPaused = true;

            //audioMixer.SetFloat("SongVolume", -80);
            ////audioMixer.SetFloat("UIVolume", -80);
            //audioMixer.SetFloat("FXVolume", -80);
        }

        public void Play()
        {
            //if (!_isPaused) return;
            //_isPaused = false;
            //int fx = PlayerPrefsMgr.Get().LoadInt("FxVolume");
            //audioMixer.SetFloat("FxVolume", PlayerPrefsMgr.Get().LoadInt("FxVolume"));
            //audioMixer.SetFloat("UiVolume", PlayerPrefsMgr.Get().LoadInt("UiVolume"));
            //audioMixer.SetFloat("SongVolume", PlayerPrefsMgr.Get().LoadInt("SongVolume"));
        }
    }
}