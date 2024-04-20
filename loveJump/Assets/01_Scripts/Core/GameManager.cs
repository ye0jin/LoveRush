using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }
}
