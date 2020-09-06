using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GJam2020.Core;
using DG.Tweening;

namespace GJam2020.Avatar
{
    public class BodyDestruction : MonoBehaviour
    {
        public static BodyDestruction Instance;

        [SerializeField]
        private ParticleSystem particleS;
        [SerializeField]
        private ParticleSystem constructParticleS;
        [Header("Body parts")]
        [SerializeField]
        private SkinnedMeshRenderer[] bodyParts;
        [SerializeField]
        private PlayerMovement playerMovement;
        private int partsDestroyed;

        private ParticleSystem.EmissionModule emission;
        private ParticleSystem.EmissionModule constructEmission;

        public int RemainingParts
        {
            get { return bodyParts.Length - partsDestroyed; }
        }

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            emission = particleS.emission;
            emission.enabled = false;

            constructEmission = constructParticleS.emission;
            constructEmission.enabled = false;
            CanvasData.Get.SetNumberOfPieces(bodyParts.Length - partsDestroyed);
            playerMovement.MovementCompleted += CheckIfGameOver;
        }
        
        [ContextMenu("DestroyBodyPart")]
        public void DestroyBodyPart()
        {
            DestroyBodyPart(1f);
        }

        public void DestroyBodyPart(float time)
        {
            if (bodyParts.Length == partsDestroyed && partsDestroyed != 0)
            {
                Debug.LogWarning("Trying to destroy more body parts than exists");
                return;
            }
            SetAlpha(bodyParts[partsDestroyed], 0.2f, time);
            Debug.Log("Destroying: " + bodyParts[partsDestroyed].name);
            StartCoroutine(EmmitParticles(particleS.gameObject));
            ++partsDestroyed;
           
            CanvasData.Get.SetNumberOfPieces(bodyParts.Length - partsDestroyed);

        }

        private void CheckIfGameOver()
        {
            if (bodyParts.Length - partsDestroyed == 0 && !LevelManager.Get.AlreadyWin)
            {
                AvatarGeneralManager.Get.Dead();
            }
        }

        private IEnumerator EmmitParticles(GameObject particleSystem)
        {
            foreach(var particleS in particleSystem.GetComponentsInChildren<ParticleSystem>())
            {
                var emission = particleS.emission;
                emission.enabled = true;
            }
            yield return new WaitForSeconds(0.3f);
            foreach (var particleS in particleSystem.GetComponentsInChildren<ParticleSystem>())
            {
                var emission = particleS.emission;
                emission.enabled = false;
            }
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
            //Debug.Log("Reconstruct body part: " + bodyParts[partsDestroyed].name);
            CanvasData.Get.SetNumberOfPieces(bodyParts.Length - partsDestroyed);
            StartCoroutine(EmmitParticles(constructParticleS.gameObject));

        }
        
        public void ReconstructAllBody()
        {
            StartCoroutine(ReconstructAllBodyCoroutine());
        }

        private IEnumerator ReconstructAllBodyCoroutine()
        {
            while(partsDestroyed > 0)
            {
                ReconstructBodyPart();
                yield return new WaitForSeconds(0.1f);
            }
            yield return null;
        }

        /// <summary>
        /// Reset body inmediately.
        /// </summary>
        [ContextMenu("ResetBodyParts")]
        public void ResetBody()
        {
            for (int index = 0; index < bodyParts.Length; index++)
                SetAlpha(bodyParts[index], 1);
            CanvasData.Get.SetNumberOfPieces(bodyParts.Length - partsDestroyed);
        }

        private void SetAlpha(SkinnedMeshRenderer skinnedMeshRenderer, float alpha, float time=0.5f)
        {
            List<Material> materials = new List<Material>();
            skinnedMeshRenderer.GetMaterials(materials);

            foreach (var mat in materials)
            {
                var matColor = mat.GetColor("_Color");
                matColor.a = alpha;
                if (alpha == 1)
                {
                    mat.DOKill();
                    mat.DOColor(matColor, 1);
                }
                else
                {
                    StartCoroutine(DisableBodyPartMaterial(mat, matColor, time));
                }
            }
        }

        private IEnumerator DisableBodyPartMaterial(Material material, Color color, float time)
        {
            Color colorEmission = material.GetColor("_EmissionColor");
            var timer = Time.time;
            Color eColor;
            float emission;
            while (Time.time - timer < time * 0.25f)
            {
                yield return new WaitForFixedUpdate();

                emission = Mathf.SmoothStep(0, 1, (Time.time - timer) / (time * 0.25f));
                eColor = Color.Lerp(colorEmission, colorEmission * 1000, emission);
                material.SetColor("_EmissionColor", eColor);
            }
            yield return new WaitForSeconds(0.25f);
            material.DOColor(color, time * 0.5f);
            timer = Time.time;
            while (Time.time - timer < time * 0.5f)
            {
                yield return new WaitForFixedUpdate();

                emission = Mathf.Lerp(1, 0, (Time.time - timer) / (time * 0.5f));
                eColor = Color.Lerp(colorEmission, colorEmission * 100, emission);
                material.SetColor("_EmissionColor", eColor);
            }
        }
    }
}