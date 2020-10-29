using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GJam2020.Core {
    public class CanvasData : MonoBehaviour
    {
        public Text NumberOfPieces;
        public Text TimeLabel;
        [SerializeField] private Transform stepsObject;
        [SerializeField] private AnimationCurve stepCurve;
        public UIInputInjecter inputActions;
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
            if (int.Parse(NumberOfPieces.text) > pieces && pieces < 4)
            {
                StartCoroutine(StepAnimation());
            }
            NumberOfPieces.text = pieces.ToString();
        }

        public void SetTime(float time)
        {
            time = Mathf.Floor(time);
            TimeLabel.text = TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
        }

        public void ResetTimer()
        {
            timer = 0;
        }
        private IEnumerator StepAnimation()
        {
            float maxTime = 0.6f;
            float timer = 0;
            while (timer <= maxTime)
            {
                float curveValue = stepCurve.Evaluate(timer / maxTime);
                stepsObject.localScale = Vector3.one * (curveValue+1);
                Color _newColor = Color.red * curveValue + Color.white * (1-curveValue);
                ChangeStepColor(_newColor);
                timer += Time.deltaTime; 
                yield return new WaitForEndOfFrame();
            }
        }
        private void ChangeStepColor(Color color)
        {
            stepsObject.GetComponentInChildren<Image>().color = color;
            stepsObject.GetComponentInChildren<Text>().color = color;
        }
    }
}
