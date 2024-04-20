using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetJump(bool value)
    {
        animator.SetBool("Jump", value);
    }
    public void SetDoubleJump(bool value)
    {
        animator.SetBool("DoubleJump", value);
    }
}
