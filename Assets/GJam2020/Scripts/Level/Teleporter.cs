using UnityEngine;
using GGJ2020.Avatar;
using GJam2020.Avatar;
using GJam2020.Core;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private AudioClip teleportClip;

    private Vector3 _localPosition;
    private Color _localColor;
    private int avatarLayer;
    private AudioSourcePlayer fxPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        avatarLayer = LayerMask.NameToLayer("Avatar");
        _localPosition = transform.position;
        fxPlayer = SoundManager.Get().FxPlayer;
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
            fxPlayer.PlayOneShot(teleportClip);
        }
    }

    public void SetColor(Color color)
    {
        _localColor = color;
    }
}
