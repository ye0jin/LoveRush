using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int Obj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Obj ==0)
        {
            Coin.Instance.SetCoin(100);
            Destroy(gameObject);
        }
        if (other.CompareTag("Player") && Obj ==1)
        {
            if (other.TryGetComponent<Player>(out Player p))
            {
                if (p.Life <= 0 || p.IsInvincibility) return;

                Destroy(gameObject);
                p.SetLife(-1);
                p.SetHurt();
            }
        }
        if (other.CompareTag("Player") && Obj ==2)
        {
            Destroy(gameObject);
            if(other.TryGetComponent<Player>(out Player p))
            {
                if (p.Life >= 3) return;
                p.SetLife(1);
                p.SetHeal();
            }
        }
    }
}
