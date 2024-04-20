using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum obstacle
{
    None = 0,
    Coin = 1,
    Obstacle = 2,
    Life = 3,
    Shelf = 4,
}
public class Obstacle : MonoBehaviour
{
    [SerializeField] private obstacle Obj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Obj == obstacle.Coin)
        {
            Coin.Instance.SetCoin(100);
            Destroy(gameObject);
        }
        if (other.CompareTag("Player") && (Obj ==obstacle.Obstacle || Obj == obstacle.Shelf))
        {
            if (other.TryGetComponent<Player>(out Player p))
            {
                if (p.Life <= 0 || p.IsInvincibility) return;

                Destroy(gameObject);

                if(Obj == obstacle.Shelf)
                {
                    Destroy(transform.parent.gameObject);
                }

                p.SetLife(-1);
                p.SetHurt();
            }
        }
        if (other.CompareTag("Player") && Obj ==obstacle.Life)
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
