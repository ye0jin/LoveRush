using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashManager : MonoBehaviour
{
    public int Life;
    [SerializeField]private List<GameObject> Heart = new List<GameObject>();

    [SerializeField] private List<GameObject> Obstacle = new List<GameObject>();

    [SerializeField] private List<GameObject> Coin = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
