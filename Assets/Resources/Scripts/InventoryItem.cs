using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
}
