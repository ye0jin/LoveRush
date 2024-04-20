using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyUI : MonoBehaviour
{
    public ItemSO item; // �Ȱ����ϴ� ������ �֤��ä��̤��� 

    [SerializeField] private GameObject panel;
    [SerializeField] private Button buyBtn;

    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI priceText;

    public void SetUI(ItemSO item)
    {
        panel.SetActive(false);
        buyBtn.interactable = true;

        this.item = item;

        infoText.text = item.ItemInfo;
        itemImage.sprite = item.ItemImage;
        priceText.text = $"{item.ItemPrice}��";
    }

    public void BuyItem()
    {
        panel.SetActive(true);
        buyBtn.interactable = false;

        Inventory.Instance.SetInventory(item);
    }
}
