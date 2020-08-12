using UnityEngine;
using GGJ2020.Avatar;
using GJam2020.Avatar;

public class Teleporter : MonoBehaviour
{
    private Vector3 _localPosition;
    private Color _localColor;
    private int avatarLayer;
    // Start is called before the first frame update
    void Start()
    {
        avatarLayer = LayerMask.NameToLayer("Avatar");
        _localPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != avatarLayer) return;
        if(AvatarPosition.CanTeleporter)
        {
            AvatarPosition.CanTeleporter = false;
            StartCoroutine(AvatarPosition.Teleporter());
            other.GetComponent<PlayerMovement>().
                UpdateMovementPosition(MapGenerator.Get.GetPairPosition(_localColor, _localPosition));
        }
    }

    public void SetColor(Color color)
    {
        _localColor = color;
    }
}
