using System;
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
        public void Move(MovementDirection dir, Action onMovementComplete)
        {
            switch (dir)
            {
                case MovementDirection.Forward:
                    transform.Translate(transform.forward);
                    break;
                case MovementDirection.Backward:
                    transform.Translate(-transform.forward);
                    break;
                case MovementDirection.Left:
                    transform.Translate(-transform.right);
                    break;
                case MovementDirection.Right:
                    transform.Translate(transform.right);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }

            onMovementComplete();
        }
    }
}
