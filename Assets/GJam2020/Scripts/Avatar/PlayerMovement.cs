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

        public void Move(MovementDirection dir, Action onMovementComplete, float timeForDisplacement)
        {
            switch (dir)
            {
                case MovementDirection.Forward:
                    StartCoroutine(MovePlayer(playerRigidbody.position + Vector3.forward, onMovementComplete, timeForDisplacement));
                    break;
                case MovementDirection.Backward:
                    StartCoroutine(MovePlayer(playerRigidbody.position + Vector3.back, onMovementComplete, timeForDisplacement));
                    break;
                case MovementDirection.Left:
                    StartCoroutine(MovePlayer(playerRigidbody.position + Vector3.left, onMovementComplete, timeForDisplacement));
                    break;
                case MovementDirection.Right:
                    StartCoroutine(MovePlayer(playerRigidbody.position + Vector3.right, onMovementComplete, timeForDisplacement));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
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