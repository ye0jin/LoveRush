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
            Destroy(gameObject);
            if (other.TryGetComponent<Player>(out Player p))
            {
                p.SetLife(-1);
            }
        }
        if (other.CompareTag("Player") && Obj ==2)
        {
            Destroy(gameObject);
            if(other.TryGetComponent<Player>(out Player p))
            {
                p.SetLife(1);
            }
        }
    }
}
