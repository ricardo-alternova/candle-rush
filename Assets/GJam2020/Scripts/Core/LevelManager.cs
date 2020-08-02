using GGJ2020.Levels;
using GJam2020.Avatar;
using GJam2020.Level.UI;
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
        [SerializeField]
        private AudioSourcePlayer _MapSongAudioPlayer;
        [SerializeField]
        private Win _winController;

        private LevelSettings settings;
        private AudioSourcePlayer _audioSource;
        public static LevelManager Get;

        public bool AlreadyWin { get; private set; } = false;

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
            get {
                AlreadyWin = false;
                return settings.NextLevel;
            }
        }
        public void Win()
        {
            AlreadyWin = true;
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

            _MapSongAudioPlayer.Stop(0.5f);
            _winController.Play();

            yield return new WaitForSeconds(_winningTime);

            LevelMenuMgr.Get().OpenWin();
            //GameManager.Get.currentLevel = NextLevel;
            //if (GameManager.Get.currentLevel == null)
            //    GameManager.Get.NewLevelComplete(LevelNumber, Score, "MainMenu");
            //else
            //    GameManager.Get.NewLevelComplete(LevelNumber, Score, "Gameplay");
        }

        private void Awake()
        {
            settings = GameManager.Get.currentLevel;
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSourcePlayer>();
            _MapSongAudioPlayer.Play(_mapSong, loop: true, delay: 0, FadeTime: 1.5f);
            Get = this;
            GameManager.Get.IsPlaying = true;
        }
    }
}