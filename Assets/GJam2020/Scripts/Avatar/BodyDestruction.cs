using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2020.Avatar
{
    public class BodyDestruction : MonoBehaviour
    {
        [SerializeField]
        private SkinnedMeshRenderer[] bodyParts;
        private int partsDestroyed = 0;
        void Start()
        {

        }

        [ContextMenu("DestroyBodyPart")]
        public void DestroyBodyPart()
        {
            if (bodyParts.Length == partsDestroyed && partsDestroyed != 0)
            {
                throw new Exception("All body parts already destroyed");
            }
            bodyParts[partsDestroyed].material.SetColor("_Color", Color.clear);

            partsDestroyed++;
        }

        [ContextMenu("ConstructBodyPart")]
        public void ReconstructBodyPart()
        {
            partsDestroyed--;
        }

        public void ResetBody()
        {
            
        }
    }
}