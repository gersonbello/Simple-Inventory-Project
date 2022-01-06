using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using TMPro;

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
    [Tooltip("Selected Slot With the Selector")]
    [SerializeField]
    private TextMeshProUGUI itemNameText;

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
    [Tooltip("Selected Item")]
    [SerializeField]
    private InventorySlot selectedItem;

    SpriteAtlas ItemsAtlas;
    PlayerActions playerInput;
    object[] items;
    int selectedInventoryIndex
    {
        get { return GetInventoryIndex(selectedSlot); }
    }

    public Sprite terstImage;
    private void Awake()
    {
        items = Resources.LoadAll("Items", typeof(InventoryItem));
        ItemsAtlas = (SpriteAtlas)Resources.Load("Sprites/Item Atlas");
        transform.DestroyAllChildrean();
        CreateSlots();
        SetInputs();
        ChangeSelection(new Vector2());
    }

    private void CreateSlots()
    {
        slots.Clear();
        slotsItems.Clear();
        transform.DestroyAllChildrean();
        while (slots.Count < inventorySize.x * inventorySize.y)
        {
            GameObject newSlot = new GameObject("Inventory Slot");
            newSlot.transform.parent = transform;
            newSlot.transform.position = new Vector3();
            newSlot.transform.localScale = new Vector3(1, 1, 1);
            slots.Add(newSlot);
            slotsItems.Add(new InventoryItem());
        }

        for (int x = 0; x < slots.Count; x++)
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
        }

        UpdateInventory();
    }

    private void ChangeSelection(Vector2 xy)
    {
        selectedSlot += new Vector2(xy.x, -xy.y);
        selectedSlot.x = Mathf.Repeat(selectedSlot.x, inventorySize.x);
        selectedSlot.y = Mathf.Repeat(selectedSlot.y, inventorySize.y);
        int slotIndex = selectedInventoryIndex;
        selectorTransform.position = slots[slotIndex].transform.position;
        if (slotsItems[slotIndex] != null) itemNameText.text = slotsItems[slotIndex].itemName;
        else itemNameText.text = "";
    }

    private void SelectSlot()
    {
        if (selectedItem != null)
        {
            if (slots[(int)selectedInventoryIndex] != null)
            {
                InventoryItem itemToChangeSlot = slotsItems[selectedInventoryIndex];
                InventorySlot slotToReciveItem = selectedItem.GetComponent<InventorySlot>();

                slotsItems[selectedInventoryIndex] = selectedItem.GetComponent<InventorySlot>().slotItem;
                slots[selectedInventoryIndex].GetComponent<InventorySlot>().slotItem = slotsItems[selectedInventoryIndex];

                slotToReciveItem.slotItem = itemToChangeSlot;
                slotsItems[slotToReciveItem.inventoryID] = itemToChangeSlot;

                selectedItem = null;
            }
        } else
        {
            selectedItem = slots[selectedInventoryIndex].GetComponent<InventorySlot>();
        }

        UpdateInventory();
    }

    private void DeleteAndRefillSlots()
    {
        if (selectedItem == null) CreateSlots();
        else
        {
            InventorySlot slotToBeDeleted = selectedItem.GetComponent<InventorySlot>();
            slotsItems[slotToBeDeleted.inventoryID] = null;
            slotToBeDeleted.slotItem = null;
            selectedItem = null;
            UpdateInventory();
        }
    }

    private void SetInputs()
    {
        playerInput = new PlayerActions();
        playerInput.Controls.Enable();
        playerInput.Controls.MoveDirection.started += ctx => 
        {
            ChangeSelection(ctx.ReadValue<Vector2>());
        };

        playerInput.Controls.AButton.started += ctx =>
        {
            SelectSlot();
        };

        playerInput.Controls.YButton.started += ctx =>
        {
            DeleteAndRefillSlots();
        };

        playerInput.Controls.LBRB.started += ctx =>
        {
            GameController.gc.ChangeResolution();
        };
    }

    private void UpdateInventory()
    {
        for(int x = 0; x < slots.Count; x++)
        {
            Image slotImage = slots[x].GetComponent<Image>();
            if (slotsItems[x] != null)
            {
                slotImage.sprite = ItemsAtlas.GetSprite(slotsItems[x].itemSprite.name);
                slotImage.SetNativeSize();
            }
            else
            {
                slotImage.sprite = null;
            }
        }
    }

    private int GetInventoryIndex(Vector2 inventoryPosition)
    {
        float indexValue = selectedSlot.x + selectedSlot.y * inventorySize.x;
        return (int)indexValue;
    }
}
