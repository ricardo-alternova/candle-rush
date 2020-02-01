using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ2020.Avatar;

namespace GGJ2020.Levels
{
    public class DisplaceGround : MonoBehaviour
    {
        [SerializeField]
        private GameObject _avatar;

        public static float GROUND_REGULAR_POS = 0;
        public static float GROUND_DISPLACED_POS = -5;
        public static float EFFECT_STARTS_AT = 5;
        public static float EFFECT_COMPLETED_AT = 3;
        private Transform localTransf;
        private float distance;
        private float lerpValue;
        private Vector3 tempV3;
        private Vector2 tempv2a;
        private Vector2 tempv2b;

        private void Awake()
        {
            localTransf = transform;
            Vector3 displacedPos = localTransf.position;
            displacedPos.y = GROUND_DISPLACED_POS;
            localTransf.position = displacedPos;
        }

        // Update is called once per frame
        void Update()
        {
            tempv2a.x = localTransf.position.x;
            tempv2a.y = localTransf.position.z;
            tempv2b.x = AvatarPosition.AVATAR_POSITION.x;
            tempv2b.y = AvatarPosition.AVATAR_POSITION.z;


            distance = Mathf.Abs((tempv2a - tempv2b).magnitude);
            //if (distance < EFFECT_STARTS_AT)
            //{
                lerpValue = (distance - EFFECT_STARTS_AT) / 
                    (EFFECT_COMPLETED_AT - EFFECT_STARTS_AT);
                
                tempV3 = localTransf.position;
                tempV3.y = Mathf.Lerp(GROUND_DISPLACED_POS, GROUND_REGULAR_POS, lerpValue);
                localTransf.position = tempV3;
            //}
            //Shader.SetGlobalVector("_AVATARposition", transform.position);
        }
    }
}