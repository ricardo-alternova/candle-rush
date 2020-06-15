using GJam2020.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace GJam2020.Avatar
{
    public class PieceReconstruct : MonoBehaviour
    {
        [SerializeField]
        private AudioClip _sound;
        private AudioSource _audioSource;
        public int PieceValue;
        private int avatarLayer;
        private Transform[] _childrensTransform;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            Assert.IsNotNull(_audioSource, "AudioSource component not found");
            _audioSource.clip = _sound;

            _childrensTransform = GetComponentsInChildren<Transform>();


            avatarLayer = LayerMask.NameToLayer("Avatar");
            GameManager.Get.AddElementToRestore(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != avatarLayer) return;

            AvatarGeneralManager.Get.CapturePiece(PieceValue);
            StartCoroutine(DestroyCoroutine());
        }

        private IEnumerator DestroyCoroutine()
        {
            _audioSource.Play();
            foreach (var child in _childrensTransform)
            {
                if (child.name == name) continue;
                child.gameObject.SetActive(false);
            }
            yield return new WaitWhile(()=> _audioSource.isPlaying);
            gameObject.SetActive(false);
        }

        [ContextMenu("Play audioclip")]
        private void PlayAudioClip()
        {
            _audioSource.Play();
        }
    }
}
