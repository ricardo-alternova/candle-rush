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
        [SerializeField] private Rigidbody playerRigidbody;
        private Vector3 _initialForward;

        private void Awake()
        {
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
                var tempObstaclePosition = new Vector3(obstaclePosition.x, 1, obstaclePosition.z);
                if ((tempObstaclePosition - futurePos).magnitude < 1)
                    isValidMovement = false;
            }
            Debug.Log(isValidMovement);
            if(isValidMovement)
                StartCoroutine(MovePlayer(futurePos, onMovementComplete, timeForDisplacement));
            else
                onMovementComplete();
            return isValidMovement;
        }

        private IEnumerator MovePlayer(Vector3 newPos, Action onMovementComplete, float timeForDisplacement)
        {
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
            var correctedPos = new Vector3((int)position.x, (int)position.y, (int)position.z);
            playerRigidbody.MovePosition(correctedPos);
            onMovementComplete();
        }

        public void ResetRotation()
        {
            playerRigidbody.rotation = Quaternion.LookRotation(_initialForward, Vector3.up);
        }
    }
}