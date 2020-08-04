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
        Debug.Log("Changing to state: " + state);
        anim.SetInteger("State", (int)state);
    }
}

public enum AnimationState { IDLE, WALKING, CELEBRATING}
