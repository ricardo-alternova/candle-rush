using UnityEngine;
using UnityEngine.UI;

namespace GJam2020.Core {
    public class CanvasData : MonoBehaviour
    {
        public Text NumberOfPieces;
        public Text TimeLabel;

        public static CanvasData Get;

        private float timer;

        private void Awake()
        {
            Get = this;

            GameManager.Get.StartGame.AddListener(() => ResetTimer());
        }

        private void Update()
        {
            if (!GameManager.Get.IsPlaying) return;

            timer += Time.deltaTime;
            SetTime(timer);
        }

        private void OnDestroy()
        {
            GameManager.Get.StartGame.RemoveListener(() => ResetTimer());
        }

        public void SetNumberOfPieces(int pieces)
        {
            NumberOfPieces.text = pieces + "";
        }

        public void SetTime(float time)
        {
            time = Mathf.Floor(time);
            TimeLabel.text = time + "";
        }

        public void ResetTimer()
        {
            timer = 0;
        }
    }
}
