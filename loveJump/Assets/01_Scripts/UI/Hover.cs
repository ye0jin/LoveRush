using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private Color originalColor;
    [SerializeField] private int But;

    private void Start()
    {
        // Cache the Button component and its original color
        button = GetComponent<Button>();
        originalColor = button.colors.normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (But == 0)
        {
            transform.DOLocalMoveY(20f, 0.5f);
        }
        if (But == 1)
        {
            transform.DOLocalMoveY(-450f, 0.5f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (But == 0)
        {
            transform.DOLocalMoveY(0f, 0.5f);
        }
        if (But == 1)
        {
            transform.DOLocalMoveY(-556f, 0.5f);
        }
    }
}