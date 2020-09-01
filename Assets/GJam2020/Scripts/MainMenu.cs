using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        //SceneManager.LoadScene(GameManager.GAMEPLAY_NAME);
        StartCoroutine(WaitSound());
    }
    private IEnumerator WaitSound()
    {
        yield return new WaitForSeconds(0.4f);
        GameManager.Get.ChargeNextLevel();
    }
}
