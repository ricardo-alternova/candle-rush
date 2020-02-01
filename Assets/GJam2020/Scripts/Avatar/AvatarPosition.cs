using UnityEngine;

namespace GGJ2020.Avatar
{
    public class AvatarPosition : MonoBehaviour
    {
        public static Vector3 AVATAR_POSITION;
        private Transform localTransf;
        // Start is called before the first frame update
        void Start()
        {
            localTransf = transform;
        }

        // Update is called once per frame
        void Update()
        {
            AVATAR_POSITION = localTransf.position;
        }
    }
}