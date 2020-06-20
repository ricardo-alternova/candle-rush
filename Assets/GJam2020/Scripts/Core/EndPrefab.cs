using GJam2020.Avatar;
using GJam2020.Core;
using UnityEngine;

public class EndPrefab : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Avatar"))
        {
            playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
                playerMovement.MovementCompleted += CharacterMovementCompleted;
        }
    }

    private void CharacterMovementCompleted()
    {
        playerMovement.MovementCompleted -= CharacterMovementCompleted;

        LevelManager.Get.PlayFinishLevel();
    }
}
