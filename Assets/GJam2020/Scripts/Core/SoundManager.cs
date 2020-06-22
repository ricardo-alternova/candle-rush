using System.Collections.Generic;
using UnityEngine;

namespace GJam2020.Core
{
    public class SoundManager : MonoBehaviour
    {
        private List<AudioSourcePlayer> _audioSourcePlayers;
        private Dictionary<AudioSourcePlayer, bool> _pauseStates;
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
                _audioSourcePlayers = new List<AudioSourcePlayer>();
            }
        }

        public static SoundManager Get() { return _instance; }
        
        public void Pause()
        {
            if (_isPaused) return;
            _isPaused = true;
            _pauseStates = new Dictionary<AudioSourcePlayer, bool>();
            foreach(var audioSourcePlayer in _audioSourcePlayers)
            {
                _pauseStates.Add(audioSourcePlayer, audioSourcePlayer.IsPlaying);
                audioSourcePlayer.Pause();
            }
        }

        public void Play()
        {
            if (!_isPaused) return;
            foreach (var pauseState in _pauseStates)
            {
                if (pauseState.Value == true)
                    pauseState.Key.Play();
            }
            _isPaused = false;
        }

        public void AddAudioPlayer(AudioSourcePlayer audioSourcePlayer)
        {
            _audioSourcePlayers.Add(audioSourcePlayer);
        }

        public void RemoveAudioPlauer(AudioSourcePlayer audioSourcePlayer)
        {
            _audioSourcePlayers.Remove(audioSourcePlayer);
        }
    }
}