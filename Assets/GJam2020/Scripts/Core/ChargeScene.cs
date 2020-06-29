using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ChargeScene : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        print(scene);
        SceneManager.LoadScene(scene);
    }

    public void LoadLevel(LevelSettings levelSettings)
    {
        GameManager.Get.currentLevel = levelSettings;
        SceneManager.LoadScene("Gameplay");
    }

    public void NextSlide()
    {

    }

    public void PreviousSlide()
    {

    }
}
