using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    public float timeWait = 2f;
    void Start()
    {
        StartCoroutine(ChargeNextScene());      
    }
    IEnumerator ChargeNextScene()
    {
        yield return new WaitForSeconds(timeWait);
        GameManager.Get.ChargeNextLevel();
    }
}
