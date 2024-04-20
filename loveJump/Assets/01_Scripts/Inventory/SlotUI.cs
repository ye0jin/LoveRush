using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public ItemSO item;

    [SerializeField] private Image itemImage;

    public void SetInventory(ItemSO item)
    {
        this.item = item;

        itemImage.sprite = item.ItemImage;  
    }
}
