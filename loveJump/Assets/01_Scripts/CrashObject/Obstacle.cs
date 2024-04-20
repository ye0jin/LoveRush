using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int Obj;
    private GameObject Manager;
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("CrashManager");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Obj ==0)
        {
            Manager.GetComponent<CrashManager>().coin += 100;
            Destroy(gameObject);
        }
        if (other.CompareTag("Player") && Obj ==1)
        {
            Manager.GetComponent<CrashManager>().Life--;
            Destroy(gameObject);
        }
        if (other.CompareTag("Player") && Obj ==2)
        {
            Destroy(gameObject);
            if (Manager.GetComponent<CrashManager>().Life < 3)
            {
                Manager.GetComponent<CrashManager>().Life++;
            }
        }
    }
}
