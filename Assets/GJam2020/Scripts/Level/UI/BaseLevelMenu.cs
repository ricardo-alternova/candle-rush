using GJam2020.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GJam2020.Level.UI
{
    public class BaseLevelMenu : MonoBehaviour
    {
        protected AudioSourcePlayer _audioSourcePlayer;

        // Start is called before the first frame update
        void Start()
        {
            _audioSourcePlayer = GetComponentInParent<AudioSourcePlayer>();
        }
    }
}