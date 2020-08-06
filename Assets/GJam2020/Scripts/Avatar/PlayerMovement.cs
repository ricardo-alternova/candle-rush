using GJam2020.Core;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

namespace GJam2020.Avatar
{
    public enum MovementDirection
    {
        Forward,
        Backward,
        Left,
        Right
    }

    public class PlayerMovement : MonoBehaviour
    {
        public event Action MovementCompleted;

        [SerializeField]
        private Rigidbody playerRigidbody;
        private Animator _animator;
        private Vector3 _initialForward;
        private Vector3 _initialPosition;
        private Vector3 _finalPosition;

        private float _currentStepTime;
        private float _actualTimeForDisplacement;
        private float _normalStepTime;
        private float _walkingTimer;
        private float _timeToAccelerate = 0.85f;
        private float _minTimeForStep = 0.35f;
        private float _startWalkingTime;
        private bool _walking;
        private MovementDirection _lastMovementDirection;
        private bool _pauseMovement;
        private bool _inputPressed;

        private void Start()
        {
            transform.localPosition = MapGenerator.Get.StartPosition;
            _animator = GetComponent<Animator>();
            Assert.IsNotNull(_animator);
            _initialForward = transform.forward;
            GameObject.Find("Systems").
                GetComponent<InputSystem>().OnInputReleased.AddListener(InputReleased);
        }

        private void InputReleased()
        {
            Debug.Log("Input released");
            _inputPressed = false;
            if(!_walking)
                AvatarGeneralManager.Get.SetStatus(AnimationState.IDLE);
        }

        private void Update()
        {           
            if (_walking)
            {
                _walkingTimer = Time.time - _startWalkingTime;
                if (_walkingTimer > _normalStepTime)
                {
                    _currentStepTime = Mathf.SmoothStep(_normalStepTime, _minTimeForStep, (_walkingTimer / _timeToAccelerate) - _normalStepTime);
                    _animator.speed = 2 - _currentStepTime;
                }
            }
        }

       
        public bool Move(MovementDirection dir, Action onMovementComplete, float timeForDisplacement)
        {
            _inputPressed = true;

            _actualTimeForDisplacement = timeForDisplacement;
            if (!_walking)
            {
                _animator.speed = 1;
                _currentStepTime = timeForDisplacement;
                _normalStepTime = timeForDisplacement;
                _startWalkingTime = Time.time;
            }

            _walking = true;

            if (LevelManager.Get.AlreadyWin) return false;
            LevelManager.Get.StartTime();
            var futurePos = Vector3.zero;            
            _lastMovementDirection = dir;
            futurePos = GetFuturePosBasedOnDirection(playerRigidbody.position,dir);
            var isValidMovement = IsValidMovement(futurePos);
            if (isValidMovement)
                StartCoroutine(MovePlayer(futurePos, onMovementComplete, _currentStepTime));
            else
            {
                AvatarGeneralManager.Get.StopWalking();
                onMovementComplete();
            }
            return isValidMovement;
        }

        public Vector3 GetFuturePosBasedOnDirection(Vector3 from,MovementDirection dir)
        {
            switch (dir)
            {
                case MovementDirection.Forward:
                    return from + Vector3.forward;
                case MovementDirection.Backward:
                    return from + Vector3.back;
                case MovementDirection.Left:
                    return from + Vector3.left;
                case MovementDirection.Right:
                    return from + Vector3.right;
                default:
                    return Vector3.zero;
            }
        }

        public bool IsValidMovement(Vector3 futurePos)
        {
            var isValidMovement = true;
            foreach (var obstaclePosition in MapGenerator.Get.GetObstaclesPosition())
            {
                var tempObstaclePosition = new Vector3(obstaclePosition.x, 0, obstaclePosition.z);
                if ((tempObstaclePosition - futurePos).magnitude < 0.8f)
                {
                    isValidMovement = false;
                }
            }
            return isValidMovement;
        }

        public void StopWalking()
        {
            _inputPressed = false;
            _walking = false;
        }

        public MovementDirection GetLastMovementDirection()
        {
            return _lastMovementDirection;
        }

        public void UpdateMovementPosition(Vector3 newInitialPosition)
        {
            var deltaPos = _finalPosition - _initialPosition;
            deltaPos = deltaPos.normalized;
            _initialPosition = newInitialPosition;
            _finalPosition = deltaPos + _initialPosition;

            var direction = (_finalPosition - _initialPosition).normalized;
            playerRigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }

        public void ResetRotation()
        {
            playerRigidbody.rotation = Quaternion.LookRotation(_initialForward, Vector3.up);
        }

        public void SetSlideAnimation(bool slide, Vector3 newFinal)
        {
            _pauseMovement = slide;
            if (slide)
            {
                _finalPosition = newFinal;
                _currentStepTime += (_actualTimeForDisplacement/2);
                Debug.LogWarning("SlideAnimation");
            }
            else
            {
                Debug.LogWarning("WalkAnimation");
            }
        }

        public Vector3 GetFinalPosition()
        {
            return _finalPosition;
        }

        private IEnumerator MovePlayer(Vector3 newPos, Action onMovementComplete, float timeForDisplacement)
        {
            AvatarGeneralManager.Get.StartMovement(_currentStepTime);

            _initialPosition = playerRigidbody.position;
            _finalPosition = newPos;

            var direction = (_finalPosition - _initialPosition).normalized;
            playerRigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);

            float timer = 0;
            while (true)
            {
                playerRigidbody.position = Vector3.Lerp(_initialPosition, _finalPosition, timer / _currentStepTime);
                timer += Time.fixedDeltaTime;
                if (timer > _currentStepTime) break;
                yield return new WaitForFixedUpdate();
            }
            
            var position = playerRigidbody.position;
            var correctedPos = new Vector3((int)(position.x + 0.5f), (int) (position.y + 0.5f), (int)
                (position.z + 0.5f));
            playerRigidbody.MovePosition(correctedPos);

            if(!_inputPressed)
                AvatarGeneralManager.Get.SetStatus(AnimationState.IDLE);

            if (MovementCompleted != null)
                MovementCompleted();
            onMovementComplete();
        }
    }
}
