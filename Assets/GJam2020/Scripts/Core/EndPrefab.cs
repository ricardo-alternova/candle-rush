using UnityEngine;

public class EndPrefab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Avatar"))
            GameManager.Get.NewLevelComplete(LevelManager.Get.LevelNumber, LevelManager.Get.Score, LevelManager.Get.NextLevel);
    }
}
