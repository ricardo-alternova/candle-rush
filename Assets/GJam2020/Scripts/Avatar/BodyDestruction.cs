using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GJam2020.Core;

namespace GJam2020.Avatar
{
    public class BodyDestruction : MonoBehaviour
    {
        public static BodyDestruction Instance;

        [SerializeField]
        private ParticleSystem particleS;
        [Header("Body parts")]
        [SerializeField]
        private SkinnedMeshRenderer[] bodyParts;
        private int partsDestroyed;
        private ParticleSystem.EmissionModule emission;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            emission = particleS.emission;
            emission.enabled = false;
            CanvasData.Get.SetNumberOfPieces(bodyParts.Length - partsDestroyed);
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
            StartCoroutine(EmmitParticles());
            ++partsDestroyed;
            if(bodyParts.Length - partsDestroyed == 0)
            {
                AvatarGeneralManager.Get.Dead();
            }
            CanvasData.Get.SetNumberOfPieces(bodyParts.Length - partsDestroyed);

        }

        private IEnumerator EmmitParticles()
        {
            emission.enabled = true;
            yield return new WaitForSeconds(0.2f);
            emission.enabled = false;

        }

        [ContextMenu("ConstructBodyPart")]
        public void ReconstructBodyPart()
        {
            partsDestroyed--;
            if (partsDestroyed < 0)
            {
                partsDestroyed = 0;
                Debug.LogWarning("All body is visible already");
                return;
            }
            SetAlpha(bodyParts[partsDestroyed], 1);
            Debug.Log("Reconstruct body part: " + bodyParts[partsDestroyed].name);
            CanvasData.Get.SetNumberOfPieces(bodyParts.Length - partsDestroyed);
        }

        [ContextMenu("ResetBodyParts")]
        public void ResetBody()
        {
            for (int index = 0; index < bodyParts.Length; index++)
                SetAlpha(bodyParts[index], 1);
            CanvasData.Get.SetNumberOfPieces(bodyParts.Length - partsDestroyed);
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