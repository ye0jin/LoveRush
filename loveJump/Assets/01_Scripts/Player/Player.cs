using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpPower;

    private bool IsJump = false; // 점프 중인지 확인
    private int currentJumpCnt = 0;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
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
        }
    }

    public void JumpOver()
    {
        IsJump = false;
        currentJumpCnt = 0;
    }
}
