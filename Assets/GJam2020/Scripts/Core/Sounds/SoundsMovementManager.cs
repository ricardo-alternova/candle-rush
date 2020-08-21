using GJam2020.Avatar;
using GJam2020.Core;
using UnityEngine;

public class SoundsMovementManager : MonoBehaviour
{
    public static SoundsMovementManager Get;

    [SerializeField]
    private AudioClip movementClip;
    [SerializeField]
    private AudioClip lowPartsMovementClip;
    [SerializeField]
    private AudioClip reverseMovementClip;

    private AudioSourcePlayer fxPlayer;

    private void Awake()
    {
        Get = this;
    }

    private void Start()
    {
        fxPlayer = SoundManager.Get().FxPlayer;
    }

    public void MovementStarted(bool isReverse)
    {
        if (isReverse)
            fxPlayer.PlayOneShot(reverseMovementClip);
        else
        {
            if (BodyDestruction.Instance.RemainingParts < 5)
                fxPlayer.PlayOneShot(lowPartsMovementClip);
            else
                fxPlayer.PlayOneShot(movementClip);
        }
    }
}
