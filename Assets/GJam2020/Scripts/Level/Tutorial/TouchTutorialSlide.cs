using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GJam2020.Game.Tutorial
{
    public class TouchTutorialSlide : BaseTutorialSlide
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnEnable()
        {
            Time.timeScale = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount == 0) return;

            if(Input.GetTouch(0).phase == TouchPhase.Began)
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