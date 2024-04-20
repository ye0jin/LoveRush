using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Coin Instance;
    public int coin;

    [SerializeField] private TextMeshProUGUI coinText;

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        UpdateCoinText();
    }

    public void UpdateCoinText()
    {
        coinText.text = $"{coin}¿ø";
    }

    internal void SetCoin(int value)
    {
        coin += value;
        UpdateCoinText();
    }
}
