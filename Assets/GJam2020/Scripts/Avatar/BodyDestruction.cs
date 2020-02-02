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
        private int partsDestroyed;
        void Start()
        {

        }

        [ContextMenu("DestroyBodyPart")]
        public void DestroyBodyPart()
        {
            if (bodyParts.Length == partsDestroyed && partsDestroyed != 0)
            {
                Debug.LogWarning("Trying to destroy more body parts than exists");
                return;
            }
            SetAlpha(bodyParts[partsDestroyed], 0);
            Debug.Log("Destroying: " + bodyParts[partsDestroyed].name);

            ++partsDestroyed;
            Debug.Log("Parts: " + partsDestroyed);
        }

        [ContextMenu("ConstructBodyPart")]
        public void ReconstructBodyPart()
        {
            partsDestroyed--;
        }

        [ContextMenu("ResetBodyParts")]
        public void ResetBody()
        {
            for (int index = 0; index < bodyParts.Length; index++)
                SetAlpha(bodyParts[index], 1);
        }

        private void SetAlpha(SkinnedMeshRenderer skinnedMeshRenderer, float alpha)
        {
            List<Material> materials = new List<Material>();
            skinnedMeshRenderer.GetMaterials(materials);

            foreach (var mat in materials)
            {
                var matColor = mat.GetColor("_Color");
                matColor.a = alpha;
                mat.SetColor("_Color", matColor);
            }
        }
    }
}