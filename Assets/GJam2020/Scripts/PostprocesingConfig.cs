using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace GJam2020.Utilities
{
    public class PostprocesingConfig : MonoBehaviour
    {
        private const float WebGLintensity = 0.01f;
        private PostProcessVolume _ppVolume;

        void Start()
        {
            _ppVolume = GetComponent<PostProcessVolume>();
#if UNITY_WEBGL
            Bloom bloomLayer;
            _ppVolume.profile.TryGetSettings(out bloomLayer);
            bloomLayer.intensity.value = WebGLintensity;
#endif
        }
    }
}