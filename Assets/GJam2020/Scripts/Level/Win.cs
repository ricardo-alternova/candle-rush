using Cinemachine;
using GGJ2020.Avatar;
using GJam2020.Avatar;
using GJam2020.Core;
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
        private AudioClip _winFx2;
        [SerializeField]
        private AudioClip _winSong;
        
        private AudioSourcePlayer _FxAudioSource;
        
        private AudioSourcePlayer _SongAudioSource;


        // Start is called before the first frame update
        void Start()
        {
            _FxAudioSource = SoundManager.Get().FxPlayer;
            _SongAudioSource = GetComponent<AudioSourcePlayer>();
            _FxAudioSource.Clip = _winFx;
            _SongAudioSource.Clip = _winSong;
        }

        [ContextMenu("Play")]
        public void Play()
        {
            _CMvirtualCam.Priority = 100;
            transform.position = AvatarPosition.AVATAR_POSITION + _particlesOffset;
            _particleSystem.gameObject.SetActive(true);
            var emission = _particleSystem.emission;
            emission.enabled = true;
            SoundsMovementManager.Get.StopSound();
            _FxAudioSource.PlayOneShot(_winFx);
            _SongAudioSource.PlayOneShot(_winSong);
            _FxAudioSource.PlayOneShot(_winFx2);

            AvatarGeneralManager.Get.GetComponent<AvatarAnimator>().SetState(AnimationState.CELEBRATING);
            Invoke("ChangeToIdleAnimation", 1);
        }

        private void ChangeToIdleAnimation()
        {
            AvatarGeneralManager.Get.GetComponent<AvatarAnimator>().SetState(AnimationState.IDLE);
        }
    }
}