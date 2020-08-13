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
        [SerializeField]
        private GameOverCtrl _gameOverCtrl;

        private LevelSettings settings;
        private AudioSourcePlayer _audioSource;

        private float timePlaying=0f;
        private bool inGame;
        public static LevelManager Get;

        public bool AlreadyWin { get; private set; } = false;

        public int LevelNumber
        {
            get { return settings.Number; }
        }

        public int Stars { get; private set; } = 1;

        public LevelSettings NextLevel
        {
            get {
                AlreadyWin = false;
                return settings.NextLevel;
            }
        }

        public void Win()
        {
            inGame = false;
            AlreadyWin = true;
            Stars = settings.GetStarts(timePlaying);
        }

        public void GameOver()
        {
            _MapSongAudioPlayer.Stop(0.5f);
            _gameOverCtrl.Play();
        }

        public void ResetGame()
        {
            _MapSongAudioPlayer.Play(_mapSong, true, 0, 0.5f);
        }

        public void StartTime()
        {
            if (!inGame)
            {
                timePlaying = 0f;
                inGame = true;
            }
        }

        private void Update()
        {
            if (inGame)
            {
                timePlaying += Time.deltaTime;
                CanvasData.Get.SetTime(timePlaying);
            }
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
            LevelMenuMgr.Get().OpenWin(Stars);
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