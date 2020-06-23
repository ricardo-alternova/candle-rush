using System.Collections;
using UnityEngine;
using static GJam2020.Core.SoundManager;

namespace GJam2020.Core
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourcePlayer : MonoBehaviour
    {
        public bool IsPlaying { get { return _audioSource.isPlaying; } }
        public AudioClip Clip;
        public SoundType _soundType;
        public bool AllowPlaying = true;

        [SerializeField]
        private bool _playOnAwake;
        private AudioSource _audioSource;      

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            if (_playOnAwake)
                Play(Clip, _audioSource.loop, 1.5f);
            SoundManager.Get().AddAudioPlayer(this);
        }

        private void OnDestroy()
        {
            SoundManager.Get().RemoveAudioPlauer(this);
        }

        public void Pause()
        {
            _audioSource.Pause();
        }

        public void Play()
        {
            if (_audioSource.clip != null && AllowPlaying)
                _audioSource.Play();
        }

        public void Stop(float fadeTime = 0)
        {
            StartCoroutine(StopCoroutine(fadeTime));
        }

        private IEnumerator StopCoroutine(float fadeTime = 0)
        {
            var partialVolume = 1 / fadeTime;
            if (_audioSource.isPlaying)
            {
                while (_audioSource.volume > 0)
                {
                    _audioSource.volume -= partialVolume * Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }
            }
        }
        
        public void Play(AudioClip clip, bool loop = false, float delay = 0, float FadeTime = 0)
        {
            StartCoroutine(PlaySoundCoroutine(clip, loop, delay, FadeTime));
        }

        private IEnumerator PlaySoundCoroutine(AudioClip clip, bool loop = false, float delay = 0, float FadeTime = 0)
        {
            var delayCounter = Time.time;
            var partialVolume = FadeTime > 0 
                ? 1 / FadeTime
                : 1;
            
            if(_audioSource.isPlaying)
            {
                if (partialVolume != 1)
                {
                    while (_audioSource.volume > 0)
                    {
                        _audioSource.volume -= partialVolume * Time.deltaTime;
                        yield return new WaitForEndOfFrame();
                    }
                }
                else
                {
                    _audioSource.volume = 0;
                }
            }
            if(Time.time - delayCounter < delay)
            {
                while(Time.time - delayCounter < delay)
                {
                    yield return new WaitForEndOfFrame();
                }
            }
            _audioSource.clip = clip;
            _audioSource.volume = 0;
            _audioSource.loop = loop;
            _audioSource.Play();

            if (FadeTime > 0)
            {
                while (_audioSource.volume < 1)
                {
                    _audioSource.volume += partialVolume * Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }
            }
            else
            {
                _audioSource.volume = 1;
            }
        }
    }
}