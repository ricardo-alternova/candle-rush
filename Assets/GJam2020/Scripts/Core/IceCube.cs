using GGJ2020.Levels;
using GJam2020.Avatar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2020.MeChanics
{
    public class IceCube : DisplaceGround
    {

        private bool _onSlide = false;
        private PlayerMovement playerMovement;
        public float slideTime;
        private float stepTime;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Avatar"))
            {
                playerMovement = other.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    //Get Direction of movement
                    MovementDirection direction = playerMovement.GetLastMovementDirection();
                    
                    if (playerMovement.IsValidMovement(playerMovement.GetFuturePosBasedOnDirection(playerMovement.GetFinalPosition(),direction))){
                        // slide in this direccion
                        playerMovement.SetSlideAnimation(true, playerMovement.GetFuturePosBasedOnDirection(playerMovement.GetFinalPosition(),direction));
                        _onSlide = true;
                        //StartCoroutine(SlidePlayer());
                    }                    
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Avatar"))
            {
                playerMovement = other.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.SetSlideAnimation(false,Vector3.zero);
                    _onSlide = false;
                }
            }
        }

        //private IEnumerator SlidePlayer()
        //{
        //    while (_onSlide)
        //    {
        //        playerMovement.SetRigidBodyPosition(Vector3.Lerp(_initialPosition, _finalPosition, timer / _currentStepTime))
        //        yield return null;
        //    }
        //}
    }
}