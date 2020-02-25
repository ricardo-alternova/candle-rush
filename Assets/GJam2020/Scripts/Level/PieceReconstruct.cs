using UnityEngine;

namespace GJam2020.Avatar
{
    public class PieceReconstruct : MonoBehaviour
    {
        public int PieceValue;
        private int avatarLayer;

        private void Start()
        {
            avatarLayer = LayerMask.NameToLayer("Avatar");
            GameManager.Get.AddElementToRestore(gameObject);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != avatarLayer) return;
            AvatarGeneralManager.Get.CapturePiece(PieceValue);
            gameObject.SetActive(false);
        }
    }
}
