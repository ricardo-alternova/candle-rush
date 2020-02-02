using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GJam2020.Avatar {
    public class AvatarGeneralManager : MonoBehaviour
    {
        public static AvatarGeneralManager Get;
        private AvatarAnimator _animator;
        private PlayerMovement _movement;
        private BodyDestruction _bodyDestruction;
        private bool _isReverse = false;

        private void Start()
        {
            Get = this;
            _animator = GetComponent<AvatarAnimator>();
            _movement = GetComponent<PlayerMovement>();
            _bodyDestruction = GetComponent<BodyDestruction>();
        }
        public void StartMovement()
        {
            if(_isReverse)
            {
                _bodyDestruction.ReconstructBodyPart();
            }
            else
            {
                _bodyDestruction.DestroyBodyPart();
            }
            _isReverse = false;
            _animator.Walking(true);

        }
        public void IsReverseCommand()
        {
            _isReverse = true;
        }
        public void EndMovement()
        {
            _animator.Walking(false);
        }
        public void CapturePiece(int value)
        {
            for(int i = 0; i < value; i++)
            {
                _bodyDestruction.ReconstructBodyPart();
            }
        }
    }
}
