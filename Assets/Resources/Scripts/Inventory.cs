using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [Header("Inventory Configuration")]
    [Tooltip("Inventory Slots Size")]
    [SerializeField]
    private Vector2 inventorySize;
    [Tooltip("Selector Transform")]
    [SerializeField]
    private Transform selectorTransform;
    [Tooltip("Selected Slot With the Selector")]
    [SerializeField]
    private Vector2 selectedSlot;

    [Header("Slots Configuration")]
    [Tooltip("Inventory Slots")]
    [SerializeField]
    private List<GameObject> slots = new List<GameObject>();
    [Tooltip("Inventory Items")]
    [SerializeField]
    private List<InventoryItem> slotsItems;
    [Tooltip("Inventory Slots Padding From Rect Transform")]
    [SerializeField]
    private Vector2 slotPadding;
    [Tooltip("Distance Between Slots")]
    [SerializeField]
    private float slotDistance = 19;

    SpriteAtlas ItemsAtlas;
    PlayerActions playerInput;

    public Sprite terstImage;
    private void Awake()
    {
        ItemsAtlas = (SpriteAtlas)Resources.Load("Sprites/Item Atlas");
        transform.DestroyAllChildrean();
        CreateSlots();
        SetInputs();
    }

    private void CreateSlots()
    {
        object[] items = Resources.LoadAll("Items", typeof(InventoryItem));
        slots.Clear();
        slotsItems.Clear();
        while (slots.Count < inventorySize.x * inventorySize.y)
        {
            GameObject newSlot = new GameObject("Inventory Slot");
            newSlot.transform.parent = transform;
            newSlot.transform.position = new Vector3();
            newSlot.transform.localScale = new Vector3(1, 1, 1);
            slots.Add(newSlot);
            slotsItems.Add(new InventoryItem());
        }

        for(int x = 0; x < slots.Count; x++)
        {
            int xPosition = (int)((x - x % inventorySize.x) / inventorySize.x);
            Vector2 xyPosition = new Vector2(x - xPosition * inventorySize.x, xPosition);

            slotsItems[x] = (InventoryItem)items[Random.Range(0, items.Length)];
            InventorySlot slot = slots[x].AddComponent<InventorySlot>();
            slot.slotItem = slotsItems[x];
            slot.inventoryID = x;
            slot.inventoryPosition = xyPosition;

            xyPosition.y *= -1;
            slots[x].transform.localPosition = slotPadding + xyPosition * slotDistance;
            Image slotImage = slots[x].AddComponent<Image>();
            slotImage.sprite = ItemsAtlas.GetSprite(slotsItems[x].itemSprite.name);
            slotImage.SetNativeSize();
        }
    }

    private void ChangeSelection(Vector2 xy)
    {
        selectedSlot += new Vector2(xy.x, -xy.y);
        selectedSlot.x = Mathf.Repeat(selectedSlot.x, inventorySize.x);
        selectedSlot.y = Mathf.Repeat(selectedSlot.y, inventorySize.y);
        float inventoryIndex = selectedSlot.x + selectedSlot.y * inventorySize.x;
        selectorTransform.position = slots[(int)inventoryIndex].transform.position;
    }

    private void SetInputs()
    {
        playerInput = new PlayerActions();
        playerInput.Controls.Enable();
        playerInput.Controls.MoveDirection.started += ctx => 
        {
            ChangeSelection(ctx.ReadValue<Vector2>());
        };
    }
}
