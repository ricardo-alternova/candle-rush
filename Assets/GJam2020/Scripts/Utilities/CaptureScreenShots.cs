using UnityEngine;

public class CaptureScreenShots : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("Capture screenshot: " + Application.dataPath);
            ScreenCapture.CaptureScreenshot("D:/" + Time.time.ToString());
        }
#endif
    }
}
