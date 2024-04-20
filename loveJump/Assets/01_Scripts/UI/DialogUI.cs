using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDialog;

    private void Start()
    {
        transform.localPosition = new Vector3(120f, -180f, 0);
    }

    public void SetDialog(string text)
    {
        transform.DOLocalMoveY(-140f, 0.5f);
        textDialog.text = text;
    }
}
