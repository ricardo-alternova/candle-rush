using System.Collections.Generic;
using UnityEngine;

namespace GJam2020.Core
{
    public class SoundManager : MonoBehaviour
    {
        public enum SoundType { SONG, UI, FX}
        public bool IsFxEnabled = true;
        public bool IsUIEnabled = true;
        public bool IsSongEnable = true;

        [SerializeField]
        private AudioSource _fxAudioSource;
        private List<AudioSourcePlayer> _audioSongPlayers;
        private List<AudioSourcePlayer> _audioUIPlayers;
        private List<AudioSourcePlayer> _audioFxPlayers;
        private Dictionary<AudioSourcePlayer, bool> _pauseSongsState;
        private Dictionary<AudioSourcePlayer, bool> _pauseUIState;
        private Dictionary<AudioSourcePlayer, bool> _pauseFxState;

        private bool _isPaused;
        private static SoundManager _instance;


        private void Awake()
        {
            if (_instance != null)
            {
                if (_instance != this)
                    Destroy(gameObject);
            }
            else
            {
                _instance = this;

                _audioSongPlayers = new List<AudioSourcePlayer>();
                _audioUIPlayers = new List<AudioSourcePlayer>();
                _audioFxPlayers = new List<AudioSourcePlayer>();
            }
        }

        private void Start()
        {
            var songEnabled = PlayerPrefsMgr.Get().LoadInt("PauseSongsState");
            if (songEnabled < 0) EnableSong(true);
            else IsSongEnable = songEnabled == 1 ? true : false;
        }

        public static SoundManager Get() { return _instance; }

        public void EnableFx(bool enable)
        {
            PlayerPrefsMgr.Get().Save<int>("PauseFxState" , enable ? 1 : 0);
            EnableTypeOfSound(enable, _pauseFxState, _audioFxPlayers);
        }

        public void EnableUI(bool enable)
        {
            PlayerPrefsMgr.Get().Save<int>("PauseUIState", enable ? 1 : 0);
            EnableTypeOfSound(enable, _pauseUIState, _audioUIPlayers);
        }

        public void EnableSong(bool enable)
        {
            IsSongEnable = enable;
            PlayerPrefsMgr.Get().Save<int>("PauseSongsState", enable ? 1 : 0);
            EnableTypeOfSound(enable, _pauseSongsState, _audioSongPlayers);
        }

        public void Pause()
        {
            if (_isPaused) return;
            _isPaused = true;

            _pauseSongsState = new Dictionary<AudioSourcePlayer, bool>();
            _pauseFxState = new Dictionary<AudioSourcePlayer, bool>();
            _pauseUIState = new Dictionary<AudioSourcePlayer, bool>();

            foreach (var audioSourcePlayer in _audioSongPlayers)
            {
                _pauseSongsState.Add(audioSourcePlayer, audioSourcePlayer.IsPlaying);
                audioSourcePlayer.Pause();
            }
            foreach (var audioSourcePlayer in _audioFxPlayers)
            {
                _pauseFxState.Add(audioSourcePlayer, audioSourcePlayer.IsPlaying);
                audioSourcePlayer.Pause();
            }
            foreach (var audioSourcePlayer in _audioUIPlayers)
            {
                _pauseUIState.Add(audioSourcePlayer, audioSourcePlayer.IsPlaying);
                audioSourcePlayer.Pause();
            }
        }

        public void Play()
        {
            if (!_isPaused) return;
            if (IsSongEnable)
            {
                foreach (var pauseState in _pauseSongsState)
                {
                    if (pauseState.Value == true)
                        pauseState.Key.Play();
                }
            }
            if (IsFxEnabled)
            {
                foreach (var pauseState in _pauseFxState)
                {
                    if (pauseState.Value == true)
                        pauseState.Key.Play();
                }
            }
            if (IsUIEnabled)
            {
                foreach (var pauseState in _pauseUIState)
                {
                    if (pauseState.Value == true)
                        pauseState.Key.Play();
                }
            }

            _isPaused = false;
        }

        public void AddAudioPlayer(AudioSourcePlayer audioSourcePlayer)
        {
            switch (audioSourcePlayer._soundType)
            {
                case SoundType.UI:
                    _audioUIPlayers.Add(audioSourcePlayer);
                    break;
                case SoundType.FX:
                    _audioFxPlayers.Add(audioSourcePlayer);
                    break;
                case SoundType.SONG:
                    _audioSongPlayers.Add(audioSourcePlayer);
                    break;
            }
        }

        public void RemoveAudioPlauer(AudioSourcePlayer audioSourcePlayer)
        {
            switch (audioSourcePlayer._soundType)
            {
                case SoundType.UI:
                    _audioUIPlayers.Add(audioSourcePlayer);
                    break;
                case SoundType.FX:
                    _audioFxPlayers.Add(audioSourcePlayer);
                    break;
                case SoundType.SONG:
                    _audioSongPlayers.Add(audioSourcePlayer);
                    break;
            }
        }

        private void EnableTypeOfSound(
            bool enable,
            Dictionary<AudioSourcePlayer, bool> audioSourcePauseStates,
            List<AudioSourcePlayer> audioSourcePlayers)
        {
            foreach (var audioSourcePlayer in audioSourcePlayers)
            {
                audioSourcePlayer.AllowPlaying = enable;
                if (enable == false)
                {
                    audioSourcePauseStates[audioSourcePlayer] = audioSourcePlayer.IsPlaying;
                    audioSourcePlayer.Stop();
                }
                else
                {
                    if (audioSourcePauseStates[audioSourcePlayer] == true)
                        audioSourcePlayer.Play();
                }
            }
        }
    }
}