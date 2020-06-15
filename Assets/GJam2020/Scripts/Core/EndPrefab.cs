using UnityEngine;

public class EndPrefab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Avatar"))
        {
            GameManager.Get.currentLevel = LevelManager.Get.NextLevel;
            if (GameManager.Get.currentLevel == null)
                GameManager.Get.NewLevelComplete(LevelManager.Get.LevelNumber, LevelManager.Get.Score, "MainMenu");
            else
                GameManager.Get.NewLevelComplete(LevelManager.Get.LevelNumber, LevelManager.Get.Score, "Gameplay");
        }
    }
}
