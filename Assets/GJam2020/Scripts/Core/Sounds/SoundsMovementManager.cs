using GJam2020.Avatar;
using GJam2020.Core;
using UnityEngine;

public class SoundsMovementManager : MonoBehaviour
{
    public static SoundsMovementManager Get;

    [SerializeField]
    private AudioSourcePlayer fxPlayer;
    [SerializeField]
    private AudioClip movementClip;
    [SerializeField]
    private AudioClip lowPartsMovementClip;
    [SerializeField]
    private AudioClip reverseMovementClip;

    private void Awake()
    {
        Get = this;
    }

    public void MovementStarted(bool isReverse)
    {
        Debug.Log("MovementStarted " + isReverse);
        if (isReverse)
            fxPlayer.Play(reverseMovementClip);
        else
        {
            if (BodyDestruction.Instance.RemainingParts < 5)
                fxPlayer.Play(lowPartsMovementClip);
            else
                fxPlayer.Play(movementClip);
        }
    }
}
