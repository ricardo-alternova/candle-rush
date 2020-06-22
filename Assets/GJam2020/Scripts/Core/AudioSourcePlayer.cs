using System.Collections;
using UnityEngine;

namespace GJam2020.Core
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourcePlayer : MonoBehaviour
    {
        public bool IsPlaying { get { return _audioSource.isPlaying; } }
        public float FadeTime = 0.7f;
        public AudioClip Clip;

        [SerializeField]
        private bool _playOnAwake;
        private AudioSource _audioSource;      

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            SoundManager.Get().AddAudioPlayer(this);
            if (_playOnAwake)
                Play(Clip, _audioSource.loop, 1.5f);
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
            if (_audioSource.clip != null)
                _audioSource.Play();
        }
        
        public void Play(AudioClip clip, bool loop = false, float delay = 0)
        {
            StartCoroutine(PlaySoundCoroutine(clip, loop, delay));
        }

        private IEnumerator PlaySoundCoroutine(AudioClip clip, bool loop = false, float delay = 0)
        {
            var delayCounter = Time.time;
            var partialVolume = 1 / FadeTime;
            var timeCounter = 0f;
            if(_audioSource.isPlaying)
            {
                while (_audioSource.volume > 0)
                {
                    _audioSource.volume -= partialVolume * Time.deltaTime;
                    yield return new WaitForEndOfFrame();
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

            while (_audioSource.volume < 1)
            {
                _audioSource.volume += partialVolume * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}