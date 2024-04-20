using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpPower;

    private bool IsJump = false; // 점프 중인지 확인
    private int currentJumpCnt = 0;
    private Rigidbody2D rigid;

    private int life;
    private PlayerAnimator animator;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<PlayerAnimator>();

        life = 3;
    }

    public void SetLife(int value)
    {
        life += value;
        life = Mathf.Clamp(life, 0, 3);

        UIManager.Instance.SetLife(life);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentJumpCnt < 2)
        {
            rigid.velocity = Vector2.zero;
            IsJump = true;

            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            //print("점프");
            currentJumpCnt++;

            if(currentJumpCnt == 1)
            {
                animator.SetJump(true);
            }
            else if(currentJumpCnt == 2)
            {
                animator.SetDoubleJump(true);
            }
        }
    }

    public void JumpOver()
    {
        animator.SetJump(false);
        animator.SetDoubleJump(false);
        IsJump = false;
        currentJumpCnt = 0;
    }
}
