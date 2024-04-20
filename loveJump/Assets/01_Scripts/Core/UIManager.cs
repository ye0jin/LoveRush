using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Life")]
    [SerializeField] private Transform lifeParent;
    [SerializeField] private HeartUI[] hearts;

    private void Awake()
    {
        if (Instance != null) print("UIManager Error");
        Instance = this;
    }

    private void Start()
    {
        hearts = lifeParent.GetComponentsInChildren<HeartUI>();
    }

    public void SetLife(int value)
    {
        for(int i = 0; i < value; ++i)
        {
            hearts[i].SetFillHeart();
        }
        for(int i = 0; i < 3 - value; ++i)
        {
            hearts[i].SetEmptyHeart();
        }
    }
}
