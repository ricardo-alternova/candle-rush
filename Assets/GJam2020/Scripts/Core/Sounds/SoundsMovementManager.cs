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
    private bool lowSteps = false;

    private void Awake()
    {
        Get = this;
    }

    private void Start()
    {
        fxPlayer = SoundManager.Get().FxPlayer;
        fxPlayer.Stop(lowPartsMovementClip);
    }

    public void MovementStarted(bool isReverse)
    {
        StartStopLowSteps(BodyDestruction.Instance.RemainingParts < 4);
        if (isReverse)
            fxPlayer.PlayOneShot(reverseMovementClip);
        else
        {
            
            fxPlayer.PlayOneShot(movementClip);
        }
    }

    private void StartStopLowSteps(bool Start)
    {
        if (Start)
        {
            if (!lowSteps)
            {
                lowSteps = true;
                fxPlayer.Play(lowPartsMovementClip, true);
            }
        }
        else
        {
            lowSteps = false;
            fxPlayer.Stop(lowPartsMovementClip);
        }
    }
}
