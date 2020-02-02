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

        private void Start()
        {
            Get = this;
            _animator = GetComponent<AvatarAnimator>();
            _movement = GetComponent<PlayerMovement>();
            _bodyDestruction = GetComponent<BodyDestruction>();
        }
        public void StartMovement()
        {
            _bodyDestruction.DestroyBodyPart();
            _animator.Walking(true);

        }

        public void EndMovement()
        {
            _animator.Walking(false);
        }
    }
}
