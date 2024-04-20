using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractionPlace : MonoBehaviour
{
    [SerializeField] private ItemSO[] listOfItem;// æ∆¿Ã≈€ ∏ÆΩ∫∆Æ (∆»∞Ì¿÷¥¬)
    
    [Header("-------buy UI------")]
    [SerializeField] private Transform interactionCanvas;
    [SerializeField] private Transform buylistParent;
    [SerializeField] private BuyUI[] buyUIs;
    [SerializeField] private BuyUI buyUIPref;

    private bool isFirstReach = true; // √∑ ¥Í¿∫ ∞≈

    private void Awake()
    {
        interactionCanvas.gameObject.SetActive(false);
    }

    private void Start()
    {
        isFirstReach = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isFirstReach)
        {
            print("dd");
            isFirstReach = false;
            StartInteraction();
        }
    }

    public void StartInteraction()
    {
        for(int i = 0; i < listOfItem.Length; ++i)
        {
            Instantiate(buyUIPref, buylistParent);
        }

        buyUIs = buylistParent.GetComponentsInChildren<BuyUI>();

        for(int i = 0; i < buyUIs.Length; ++i)
        {
            buyUIs[i].SetUI(listOfItem[i]);
        }

        Time.timeScale = 0;
        interactionCanvas.gameObject.SetActive(true);
        interactionCanvas.DOLocalMoveY(0, 1.2f).SetUpdate(true);
    }
    public void EndInteraction()
    {
        interactionCanvas.DOLocalMoveY(1060f, 1.2f).SetUpdate(true).OnComplete(() => 
        {
            interactionCanvas.gameObject.SetActive(false);
            for (int i = 0; i < buyUIs.Length; ++i)
            {
                Destroy(buyUIs[i].gameObject);
            }
            Time.timeScale = 1;
        });
    }
}
