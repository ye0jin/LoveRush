using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum checkPoint
{
    None = 0,
    ScreenTransition = 1,
    End = 2
}
public class CheckPoint : MonoBehaviour
{
    [SerializeField] private checkPoint point;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(point == checkPoint.ScreenTransition)
        {
            UIManager.Instance.DoFadeImage();
        }
        else if(point == checkPoint.End)
        {
            UIManager.Instance.DoSceneChange(2);
        }
    }
}
