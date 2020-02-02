using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GJam2020.Avatar
{
    public class PieceReconstruct : MonoBehaviour
    {
        public int PieceValue;
        private void OnTriggerEnter(Collider other)
        {
            AvatarGeneralManager.Get.CapturePiece(PieceValue);
            Destroy(gameObject);
        }
    }
}
