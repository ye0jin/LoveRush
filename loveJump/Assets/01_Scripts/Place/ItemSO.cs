using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Item")]
public class ItemSO : ScriptableObject
{
    public Sprite ItemImage;
    [TextArea] public string ItemInfo;
    public int ItemPrice;
}
