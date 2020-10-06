using UnityEngine;

public class AvatarAnimator : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetState(AnimationState state)
    {
        anim.SetInteger("State", (int)state);
    }

    public void IsSlide(bool Slide)
    {
        anim.SetBool("slide", Slide);
    }

    public AnimationState GetState()
    {
        var state = anim.GetInteger("State");
        return (AnimationState)state;
    }
}

public enum AnimationState {
    IDLE,
    WALKING,
    CELEBRATING,
    FALL_SLEEP,
    SLIP_OFF,
    GAME_OVER
    }
