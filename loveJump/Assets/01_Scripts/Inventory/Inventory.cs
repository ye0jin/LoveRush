using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [SerializeField] private Transform inventoryParent;
    [SerializeField] private SlotUI invenPref;

    public List<ItemSO> inventoryList;

    private void Awake()
    {
        if (Instance != null)
        {
            print("인벤토리 에러");
        }
        Instance = this;
    }

    public void SetInventory(ItemSO item)
    {
        inventoryList.Add(item);

        SlotUI newItem = Instantiate(invenPref, inventoryParent);
        newItem.SetInventory(item);
    }
}
