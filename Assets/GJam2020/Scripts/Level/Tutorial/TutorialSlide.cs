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

        private InputSystem _inputSystem;

        public override void Hide()
        {
            if (_inputSystem == null) return;
            _inputSystem.OnMove -= MoveInput;
            base.Hide();
            Invoke("DisableGO", 0.5f);
        }
        
        private void OnEnable()
        {
            _inputSystem = GameObject.Find("Systems").GetComponent<InputSystem>();
            Assert.IsNotNull(_inputSystem);
            
            StartCoroutine(EnableCoroutine());
        }
        
        private IEnumerator EnableCoroutine()
        {
            yield return new WaitForSeconds(_delay);
            
            _inputSystem.EnableInputs(
                _direction == Vector2.left,
                _direction == Vector2.right,
                _direction == Vector2.up,
                _direction == Vector2.down
                );

            _inputSystem.OnMove += MoveInput;
        }

        private void MoveInput(Vector2 direction)
        {
            if (direction != _direction) return;

            GetComponentInParent<TutorialController>().NextSlide();
        }
    }
}