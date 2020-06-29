using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace GJam2020.Utilities
{
    public class PostprocesingConfig : MonoBehaviour
    {

        private PostProcessVolume _ppVolume;
        // Start is called before the first frame update
        void Start()
        {
            _ppVolume = GetComponent<PostProcessVolume>();
#if UNITY_WEBGL
            Bloom bloomLayer;
            _ppVolume.profile.TryGetSettings(out bloomLayer);
            bloomLayer.intensity.value = 0.01f;
#endif
        }
    }
}