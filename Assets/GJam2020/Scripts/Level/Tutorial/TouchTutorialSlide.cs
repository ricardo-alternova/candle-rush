using GJam2020.Core;
using UnityEngine;
using UnityEngine.Assertions;

namespace GJam2020.Game.Tutorial
{
    public class TouchTutorialSlide : BaseTutorialSlide
    {
        private InputSystem _inputSystem;
        public float startTime;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnEnable()
        {
            _inputSystem = GameObject.Find("Systems").GetComponent<InputSystem>();
            Assert.IsNotNull(_inputSystem);

            startTime = Time.realtimeSinceStartup;
            Invoke("StartBehavior", 2);
            Time.timeScale = 0;
        }

        public override void Hide()
        {
            Time.timeScale = 1;
            base.Hide();
            Invoke("DisableGO", 0.5f);
        }

        private void Update()
        {
            if (Time.realtimeSinceStartup - startTime < 2) return;

            if (Input.anyKey || 
                Input.GetAxis("Horizontal") > 0 ||
                Input.GetAxis("Vertical") > 0)
            {
                GetComponentInParent<TutorialController>().NextSlide();
            }
        }
        
        private void OnDisable()
        {
            Time.timeScale = 1;
        }
    }
}