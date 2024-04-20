using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BuyUI : MonoBehaviour
{
    private InteractionPlace connectPlace;
    private bool CanBuy = false;

    public ItemSO item; // �Ȱ����ϴ� ������ �֤��ä��̤��� 

    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI priceText;

    public void SetUI(ItemSO item, InteractionPlace connect)
    {
        CanBuy = true;

        this.item = item;
        connectPlace = connect;

        infoText.text = item.ItemInfo;
        itemImage.sprite = item.ItemImage;
        priceText.text = $"{item.ItemPrice}��";

        if (Coin.Instance.coin < item.ItemPrice)
        {
            CanBuy = false;
            transform.Find("BuyButton").GetComponent<Button>().interactable = false;
            priceText.text = $"{item.ItemPrice}��";
        }
    }

    public bool ReturnBuy()
    {
        return CanBuy;
    }

    public void BuyItem()
    {
        if (!CanBuy)
        {
            return;
        }
        Inventory.Instance.SetInventory(item);
        Coin.Instance.SetCoin(-item.ItemPrice);
        connectPlace.EndInteraction();
    }
}
