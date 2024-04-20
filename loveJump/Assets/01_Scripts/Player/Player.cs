using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private float timeOfSakura;

    private bool IsJump = false; // 점프 중인지 확인
    private bool isInvincibility = false; // 무적인지 확인
    public bool IsInvincibility => isInvincibility; // 무적인지 확인

    private int currentJumpCnt = 0;

    private Rigidbody2D rigid;
    private SpriteRenderer sr;

    private int life;
    public int Life => life;
    private PlayerAnimator animator;

    [Header("파티클")]
    [SerializeField] private GameObject healParticle;
    [SerializeField] private GameObject sakuraParticle;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<PlayerAnimator>();
        sr = GetComponent<SpriteRenderer>();

        life = 3;
    }

    #region 라이프
    public void SetLife(int value)
    {
        life += value;
        life = Mathf.Clamp(life, 0, 3);

        if (life <= 0)
        {
            SetDead();
        }

        UIManager.Instance.SetLife(life);
    }
    public void SetDead()
    {
        animator.SetDead();
        transform.DOLocalMoveY(-3.56f, 0.5f).SetUpdate(true);
        GameManager.Instance.GameOver();
    }
    public void SetHeal()
    {
        SoundManager.Instance.PlayHealSound();
        GameObject ps = Instantiate(healParticle, this.transform);
        Destroy(ps, 1f);
    }
    public void SetHurt()
    {
        StartCoroutine(HurtCor());
    }
    private IEnumerator HurtCor()
    {
        isInvincibility = true;

        Color originalColor = sr.color; 
        sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.6f);

        for (int i = 0; i < 2; i++)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }

        sr.color = originalColor;

        yield return new WaitForSeconds(0.4f);
        isInvincibility = false;
    }
    #endregion

    #region 아이템
    public void SetChocoItem()
    {
        UIManager.Instance.SetInfoText("여친의 수제 초코 획득! (체력 회복)");
        SetLife(1);
        SetHeal();
    }
    public void SetCherryBlossomItem()
    {
        SoundManager.Instance.PlaySakuraSound();
        UIManager.Instance.SetInfoText("여친이 잡아준 벚꽃 획득! (5초간 무적)");
        StartCoroutine(SetInvincibility());
    }
    private IEnumerator SetInvincibility()
    {
        GameObject obj = Instantiate(sakuraParticle);

        isInvincibility = true;
        sr.color = new Vector4(1, 1, 1, 0.8f);
        yield return new WaitForSeconds(timeOfSakura);
        isInvincibility = false;
        sr.color = Vector4.one;

        Destroy(obj);
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentJumpCnt < 2 && !GameManager.Instance.IsGameOver)
        {
            SoundManager.Instance.PlayJumpSound();

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
