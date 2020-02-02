using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAnimator : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Walking(bool walking) {
        anim.SetInteger("State", walking?1:0);
    }
}
