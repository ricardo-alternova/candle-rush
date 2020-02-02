using UnityEngine;
using GGJ2020.Avatar;

namespace GGJ2020.Levels
{
    public class DisplaceGround : MonoBehaviour
    {
        public float GROUND_REGULAR_POS = 0;
        public float GROUND_DISPLACED_POS = -4;
        private float displacement = -4;
        public static float EFFECT_STARTS_AT = 5;
        public static float EFFECT_COMPLETED_AT = 2.5f;
        private Transform localTransf;
        private float distance;
        private float lerpValue;
        private Vector3 tempV3;
        private Vector2 tempv2a;
        private Vector2 tempv2b;

        private void Start()
        {
            localTransf = transform;
            GROUND_REGULAR_POS = localTransf.position.y;
            GROUND_DISPLACED_POS = GROUND_REGULAR_POS + displacement;
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
            lerpValue = (distance - EFFECT_STARTS_AT) /
                (EFFECT_COMPLETED_AT - EFFECT_STARTS_AT);

            tempV3 = localTransf.position;
            tempV3.y = Mathf.Lerp(GROUND_DISPLACED_POS, GROUND_REGULAR_POS, lerpValue);
            localTransf.position = tempV3;
        }
    }
}