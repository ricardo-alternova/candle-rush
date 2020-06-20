using System;
using System.Collections;
using UnityEngine;

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
        private Vector3 _initialForward;
        private Vector3 _initialPosition;
        private Vector3 _finalPosition;

        private void Awake()
        {
            
        }

        private void Start()
        {
            transform.localPosition = MapGenerator.Get.StartPosition;
            _initialForward = transform.forward;
        }

        public bool Move(MovementDirection dir, Action onMovementComplete, float timeForDisplacement)
        {
            var futurePos = Vector3.zero;
            var isValidMovement = true;

            switch (dir)
            {
                case MovementDirection.Forward:
                    futurePos = playerRigidbody.position + Vector3.forward;
                    break;
                case MovementDirection.Backward:
                    futurePos = playerRigidbody.position + Vector3.back;
                    break;
                case MovementDirection.Left:
                    futurePos = playerRigidbody.position + Vector3.left;
                    break;
                case MovementDirection.Right:
                    futurePos = playerRigidbody.position + Vector3.right;
                    break;
            }

            foreach (var obstaclePosition in MapGenerator.Get.GetObstaclesPosition())
            {
                var tempObstaclePosition = new Vector3(obstaclePosition.x, 0, obstaclePosition.z);
                if ((tempObstaclePosition - futurePos).magnitude < 0.8f)
                {
                    isValidMovement = false;
                }
            }
            if(isValidMovement)
                StartCoroutine(MovePlayer(futurePos, onMovementComplete, timeForDisplacement));
            else
            {

                AvatarGeneralManager.Get.EndMovement();
                onMovementComplete();
            }
            return isValidMovement;
        }

        public void UpdateMovementPosition(Vector3 newInitialPosition)
        {
            var deltaPos = _finalPosition - _initialPosition;
            _initialPosition = newInitialPosition;
            _finalPosition = deltaPos + _initialPosition;

            var direction = (_finalPosition - _initialPosition).normalized;
            playerRigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }

        public void ResetRotation()
        {
            playerRigidbody.rotation = Quaternion.LookRotation(_initialForward, Vector3.up);
        }

        private IEnumerator MovePlayer(Vector3 newPos, Action onMovementComplete, float timeForDisplacement)
        {
            AvatarGeneralManager.Get.StartMovement();

            _initialPosition = playerRigidbody.position;
            _finalPosition = newPos;

            var direction = (_finalPosition - _initialPosition).normalized;
            playerRigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);

            float timer = 0;
            while (true)
            {
                playerRigidbody.position = Vector3.Lerp(_initialPosition, _finalPosition, timer / timeForDisplacement);
                timer += Time.deltaTime;
                if (timer > timeForDisplacement) break;
                yield return new WaitForEndOfFrame();
            }

            var position = playerRigidbody.position;
            var correctedPos = new Vector3((int)(position.x + 0.5f), (int) (position.y + 0.5f), (int)
                (position.z + 0.5f));
            playerRigidbody.MovePosition(correctedPos);
            AvatarGeneralManager.Get.EndMovement();
            if (MovementCompleted != null)
                MovementCompleted();
            onMovementComplete();
        }
    }
}