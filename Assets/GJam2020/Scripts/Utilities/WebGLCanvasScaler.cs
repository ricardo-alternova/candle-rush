using UnityEngine;
using UnityEngine.UI;

public class WebGLCanvasScaler : MonoBehaviour
{
    [SerializeField]
    private float webScaleFactor = 0.29f;
    [SerializeField]
    private float mobileScaleFactor = 0.29f;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WEBGL
        SetWebGLCanvasSize(webScaleFactor);
#else
        SetWebGLCanvasSize(mobileScaleFactor);
#endif
    }

    private void SetWebGLCanvasSize(float scaleFactor)
    {
        var canvasScaler = GetComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        canvasScaler.scaleFactor = scaleFactor;
        Debug.Log("Canvas scaler set to: " + scaleFactor);
    }
}
