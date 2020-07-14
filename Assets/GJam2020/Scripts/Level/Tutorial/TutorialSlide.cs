using System.Collections;
using GJam2020.Core;
using UnityEngine;
using UnityEngine.Assertions;

namespace GJam2020.Game.Tutorial
{
    public class TutorialSlide : BaseTutorialSlide
    {
        [Tooltip("Completed when input is on this direction")]
        [SerializeField]
        private Vector2 _direction;
        
        private void OnEnable()
        {
            InputSystem inputSystem = GameObject.Find("Systems").GetComponent<InputSystem>();
            Assert.IsNotNull(inputSystem);

            inputSystem.OnMove += MoveInput;

            StartCoroutine(EnableCoroutine());
        }

        private IEnumerator EnableCoroutine()
        {
            yield return new WaitForSeconds(_delay);
        }

        private void MoveInput(Vector2 direction)
        {
            if (direction != _direction) return;

            GetComponentInParent<TutorialController>().NextSlide();
        }

        private void OnDisable()
        {
            var systemsGO = GameObject.Find("Systems");
            if (systemsGO == null) return;
            InputSystem inputSystem = systemsGO.GetComponent<InputSystem>();
            Assert.IsNotNull(inputSystem);
            inputSystem.OnMove -= MoveInput;
        }
    }
}