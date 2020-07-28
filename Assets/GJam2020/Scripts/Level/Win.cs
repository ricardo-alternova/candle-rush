using Cinemachine;
using GGJ2020.Avatar;
using UnityEngine;

namespace GGJ2020.Levels
{
    public class Win : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particleSystem;
        [SerializeField]
        private float _duration = 2;
        [SerializeField]
        private Vector3 _particlesOffset;
        [SerializeField]
        private CinemachineVirtualCamera _CMvirtualCam;
        [SerializeField]
        private AudioClip _winFx;
        [SerializeField]
        private AudioClip _winSong;
        [SerializeField]
        private AudioSource _FxAudioSource;
        [SerializeField]
        private AudioSource _SongAudioSource;


        // Start is called before the first frame update
        void Start()
        {
            _FxAudioSource.clip = _winFx;
            _SongAudioSource.clip = _winSong;
        }

        [ContextMenu("Play")]
        public void Play()
        {
            _CMvirtualCam.Priority = 100;
            transform.position = AvatarPosition.AVATAR_POSITION + _particlesOffset;
            _particleSystem.gameObject.SetActive(true);
            var emission = _particleSystem.emission;
            emission.enabled = true;

            _FxAudioSource.Play();
            _SongAudioSource.Play();
        }
    }
}