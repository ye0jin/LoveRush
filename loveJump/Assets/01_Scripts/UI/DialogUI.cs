using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDialog;

    public void SetDialog(string text, float x = 120f)
    {
        transform.localPosition = new Vector3(x, -180f, 0);
        //print(x);
        transform.DOLocalMoveY(-140f, 0.5f);
        textDialog.text = text;
    }
}
