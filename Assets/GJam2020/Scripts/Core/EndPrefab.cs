using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPrefab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Get.NewLevelComplete(LevelManager.Get.LevelNumber, LevelManager.Get.Score, LevelManager.Get.NextLevel);
    }
}
