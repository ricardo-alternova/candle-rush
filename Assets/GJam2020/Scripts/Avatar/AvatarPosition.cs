using UnityEngine;
using System.Collections;

namespace GGJ2020.Avatar
{
    public class AvatarPosition : MonoBehaviour
    {
        public static Vector3 AVATAR_POSITION;
        public static bool CanTeleporter = true;

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

        public static IEnumerator Teleporter()
        {
            yield return new WaitForSeconds(5f);
            CanTeleporter = true;
        }
    }
}