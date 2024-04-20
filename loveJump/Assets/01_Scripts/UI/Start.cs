using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Start : MonoBehaviour
{
    public GameObject Obj;
    public void Move()
    {
        Obj.transform.DOLocalMoveY(5000f, 3f);
    }

    public void SceneMove()
    {
        //씬 이동 넣기
    }
}
