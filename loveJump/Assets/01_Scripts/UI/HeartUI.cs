using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HeartUI : MonoBehaviour
{
    [SerializeField] private Sprite fill;
    [SerializeField] private Sprite empty;

    private Image heartImage;

    private void Start()
    {
        heartImage = GetComponent<Image>();
    }
        
    public void SetFillHeart()
    {
        if (heartImage.sprite != fill)
        {
            transform.DOScale(0.55f, 0.2f).OnComplete(() => transform.DOScale(0.5f, 0.3f).SetUpdate(true)).SetUpdate(true);
        }
        heartImage.sprite = fill;
    }
    public void SetEmptyHeart()
    {
        if (heartImage.sprite != empty)
        {
            transform.DOScale(0.55f, 0.2f).OnComplete(() => transform.DOScale(0.5f, 0.3f).SetUpdate(true)).SetUpdate(true);
        }
        heartImage.sprite = empty;
    }
}
