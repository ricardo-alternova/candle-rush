using System.Collections;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadScene()
    {
        StartCoroutine(WaitSound());
    }
    private IEnumerator WaitSound()
    {
        yield return new WaitForSeconds(0.4f);
        GameManager.Get.ChargeOrReload();
    }
}
