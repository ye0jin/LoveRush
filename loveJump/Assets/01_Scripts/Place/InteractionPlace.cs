using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractionPlace : MonoBehaviour
{
    [SerializeField] private ItemSO[] listOfItem;// æ∆¿Ã≈€ ∏ÆΩ∫∆Æ (∆»∞Ì¿÷¥¬)
    
    [Header("-------buy UI------")]
    [SerializeField] private Transform buylistParent;
    [SerializeField] private BuyUI[] buyUIs;
    [SerializeField] private BuyUI buyUIPref;

    private bool isFirstReach = true; // √∑ ¥Í¿∫ ∞≈

    private void Awake()
    {
        buylistParent.gameObject.SetActive(false);
    }

    private void Start()
    {
        isFirstReach = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isFirstReach)
        {
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

        int cnt = 0;
        for(int i = 0; i < buyUIs.Length; ++i)
        {
            buyUIs[i].SetUI(listOfItem[i], this);
            if (!buyUIs[i].ReturnBuy())
            {
                cnt++;
            }
        }

        Time.timeScale = 0;
        buylistParent.gameObject.SetActive(true);

        buylistParent.DOLocalMoveY(-40f, 1.2f).SetUpdate(true);
    }
    public void EndInteraction()
    {
        buylistParent.DOLocalMoveY(1060f, 1.2f).SetUpdate(true).OnComplete(() => 
        {
            buylistParent.gameObject.SetActive(false);
            for (int i = 0; i < buyUIs.Length; ++i)
            {
                Destroy(buyUIs[i].gameObject);
            }
            Time.timeScale = 1;
        });
    }
}
