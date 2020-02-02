using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAnimator : MonoBehaviour
{
    public Animator anim;

    public void Walking(bool walking) {
        anim.SetInteger("State", walking?1:0);
    }
}
