using UnityEngine;
using GGJ2020.Avatar;

namespace GGJ2020.Levels
{
    public class DisplaceGround : MonoBehaviour
    {
        public float GROUND_REGULAR_POS = 0;
        public float GROUND_DISPLACED_POS = -4;
        public static float EFFECT_STARTS_AT = 5;
        public static float EFFECT_COMPLETED_AT = 2.5f;
        public int layerMask;

        private const string NormalGroundName = "NormalGround";
        private float displacement = -4;
        private Transform localTransf;
        private Quaternion initQuaternion;
        private Quaternion finalRotation;
        private float distance;
        private float lerpValue;
        private Vector3 tempV3;
        private Vector2 tempv2a;
        private Vector2 tempv2b;
        private bool onRange;

        private void Start()
        {
            layerMask = LayerMask.NameToLayer("AvatarArea");
            initQuaternion = GetRandomRotation();
            finalRotation = name.Contains("NormalGround")
                ? GetRandomInitialRotation()
                : Quaternion.identity;

            localTransf = transform;
            localTransf.localRotation = initQuaternion;
            GROUND_REGULAR_POS = localTransf.position.y;
            GROUND_DISPLACED_POS = GROUND_REGULAR_POS + displacement;
            Vector3 displacedPos = localTransf.position;
            displacedPos.y = GROUND_DISPLACED_POS;
            localTransf.position = displacedPos;
        }

        // Update is called once per frame
        void Update()
        {
            if (!onRange) return;
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

            var quat = Quaternion.Slerp(initQuaternion, finalRotation, lerpValue);
            localTransf.localRotation = quat;
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == layerMask)
                onRange = false;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == layerMask)
                onRange = true;
        }

        private Quaternion GetRandomRotation()
        {
            var maxAngle = 45;
            var quat = new Quaternion(
                Random.Range(-maxAngle, maxAngle),
                Random.Range(-maxAngle, maxAngle),
                Random.Range(-maxAngle, maxAngle),1);
            return quat.normalized;
        }

        private Quaternion GetRandomInitialRotation()
        {
            int rotation = Random.Range(0, 5);
            Vector3 finalDir = Vector3.up;
            switch (rotation)
            {
                case 0:
                    finalDir = Vector3.forward;
                    break;
                case 1:
                    finalDir = Vector3.back;
                    break;
                case 2:
                    finalDir = Vector3.right;
                    break;
                case 3:
                    finalDir = Vector3.left;
                    break;
                case 4:
                    finalDir = Vector3.up;
                    break;
                case 5:
                    finalDir = Vector3.down;
                    break;
            }
            var quat = Quaternion.FromToRotation(Vector3.up, finalDir);
            return quat.normalized;
        }
    }
}