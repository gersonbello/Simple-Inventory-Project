using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Inventory Configuration")]
    [Tooltip("Inventory Slots Size")]
    [SerializeField]
    private Vector2 inventorySize;

    [Header("Slots Configuration")]
    [Tooltip("Inventory Slots And Itens")]
    [SerializeField]
    private List<GameObject> slots = new List<GameObject>();
    [Tooltip("Inventory Slots And Itens")]
    [SerializeField]
    private Vector2 slotPadding;
    [Tooltip("Distance Between Slots")]
    [SerializeField]
    private float slotDistance = 19;

    private void Awake()
    {
        GameObject slotOBJ = transform.GetChild(0).gameObject;
        transform.DestroyAllChildrean();
        for (int x = 0; x < inventorySize.x; x++)
        {
            for (int y = 0; y < inventorySize.y; y++)
            {
                Instantiate(slotOBJ, transform).transform.localPosition = slotPadding + new Vector2(x, y) * slotDistance;
            }
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
    }
#endif
}
