using GGJ2020.Levels;
using GJam2020.Avatar;
using GJam2020.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2020.MeChanics
{
    public class IceCube : DisplaceGround
    {
        [SerializeField]
        private AudioClip iceClip;
        private AudioSourcePlayer fxPlayer;
        private void Start()
        {
            fxPlayer = SoundManager.Get().FxPlayer;
        }

        protected override void OnPlayerTrigger()
        {
            AvatarGeneralManager.Get.SetCurrentGround(MapEntity.iceCube);
            MovementDirection direction = playerMovement.GetLastMovementDirection();
            if (playerMovement.IsValidMovement(playerMovement.GetFuturePosBasedOnDirection(playerMovement.GetFinalPosition(), direction)))
            {
                playerMovement.SetNewFinalPosition(playerMovement.GetFuturePosBasedOnDirection(playerMovement.GetFinalPosition(), direction));
                fxPlayer.PlayOneShot(iceClip);
            }
        }


    }
}