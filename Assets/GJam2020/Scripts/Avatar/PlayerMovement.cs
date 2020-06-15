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

        private void Awake()
        {
            transform.localPosition = GameManager.Get.currentLevel.StartLocation;
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

        private IEnumerator MovePlayer(Vector3 newPos, Action onMovementComplete, float timeForDisplacement)
        {
            AvatarGeneralManager.Get.StartMovement();
            var displacement = newPos - playerRigidbody.position;
            var distance = displacement.magnitude;
            var speed = distance / timeForDisplacement;
            var direction = displacement.normalized;
            playerRigidbody.rotation = Quaternion.LookRotation(direction,Vector3.up);
            var initialTime = Time.time;
            var timeInDisplacement = initialTime;
            while (timeInDisplacement < initialTime+ timeForDisplacement)
            {
                playerRigidbody.position += Time.deltaTime * speed * direction; 
                timeInDisplacement += Time.deltaTime;
                yield return null;
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

        public void ResetRotation()
        {
            playerRigidbody.rotation = Quaternion.LookRotation(_initialForward, Vector3.up);
        }
    }
}