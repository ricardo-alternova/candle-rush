using GJam2020.Avatar;
using System.Collections;
using UnityEngine;

namespace GJam2020.Core
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private float _winningTime = 3;
        [SerializeField]
        private AudioClip _winningSound;
        [SerializeField]
        private AudioClip _mapSong;
        private LevelSettings settings;
        private AudioSourcePlayer _audioSource;

        public static LevelManager Get;

        public int LevelNumber
        {
            get { return settings.Number; }
        }

        public int Score
        {
            get { return settings.Score; }
        }

        public LevelSettings NextLevel
        {
            get { return settings.NextLevel; }
        }

        public void PlayFinishLevel()
        {
            StartCoroutine(PlayFinishCoroutine());
        }

        private IEnumerator PlayFinishCoroutine()
        {
            BodyDestruction.Instance.ReconstructAllBody();
            var playerMovement = BodyDestruction.Instance.GetComponent<PlayerMovement>();
            playerMovement.ResetRotation();
            
            _audioSource.FadeTime = 0.4f;
            _audioSource.Play(_winningSound);

            yield return new WaitForSeconds(_winningTime);


            GameManager.Get.currentLevel = NextLevel;
            if (GameManager.Get.currentLevel == null)
                GameManager.Get.NewLevelComplete(LevelNumber, Score, "MainMenu");
            else
                GameManager.Get.NewLevelComplete(LevelNumber, Score, "Gameplay");
        }

        private void Awake()
        {
            settings = GameManager.Get.currentLevel;
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSourcePlayer>();
            _audioSource.FadeTime = 1.5f;
            _audioSource.Play(_mapSong, loop: true, 0.5f);
            Get = this;
        }
    }
}