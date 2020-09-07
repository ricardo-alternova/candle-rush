using UnityEngine;
using UnityEngine.UI;

public class WebGLCanvasScaler : MonoBehaviour
{
    [SerializeField]
    private float scaleFactor = 0.56f;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WEBGL
        SetWebGLCanvasSize();
#endif
    }

    private void SetWebGLCanvasSize()
    {
        var canvasScaler = GetComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        canvasScaler.scaleFactor = scaleFactor;
        Debug.Log("Canvas scaler set to: " + scaleFactor);
    }
}
