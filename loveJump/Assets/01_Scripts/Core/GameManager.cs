using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver;

    public static GameManager Instance;
    public Camera mainCam;

    private void Awake()
    {
        Instance = this;
        mainCam = Camera.main;
    }
    public void GameOver()
    {
        IsGameOver = true;

        UIManager.Instance.DoFadeInImage();
    }
}
