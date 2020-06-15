using GJam2020.Avatar;
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

        GameManager.Get.currentLevel = LevelManager.Get.NextLevel;
        if (GameManager.Get.currentLevel == null)
            GameManager.Get.NewLevelComplete(LevelManager.Get.LevelNumber, LevelManager.Get.Score, "MainMenu");
        else
            GameManager.Get.NewLevelComplete(LevelManager.Get.LevelNumber, LevelManager.Get.Score, "Gameplay");
    }
}
