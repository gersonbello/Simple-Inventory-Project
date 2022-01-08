using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using TMPro;

public class Inventory : MonoBehaviour
{
    [Header("Inventory Configuration")]
    [Tooltip("Inventory slots size")]
    [SerializeField]
    private Vector2 inventorySize;
    [Tooltip("Selector that indicates the current slot")]
    [SerializeField]
    private Transform selectorTransform;
    [Tooltip("Selector that Indicates the selected slot")]
    [SerializeField]
    private Transform selectedSelectorTransform;
    [Tooltip("Selector that indicates the picked object")]
    [SerializeField]
    private Transform pickedObjectIndicator;
    [Tooltip("Image of the picked object")]
    [SerializeField]
    private Image pickedItemRepresentation;
    [Tooltip("Selected slot with the selector")]
    [SerializeField]
    private Vector2 selectedSlot;
    [Tooltip("Selected slot with the selector")]
    [SerializeField]
    private TextMeshProUGUI itemNameText;

    [Header("Slots Configuration")]
    [Tooltip("Inventory slots")]
    [SerializeField]
    private List<GameObject> slots = new List<GameObject>();
    [Tooltip("Inventory items")]
    [SerializeField]
    private List<InventoryItem> slotsItems;
    [Tooltip("Inventory slots padding from rect transform")]
    [SerializeField]
    private Vector2 slotPadding;
    [Tooltip("Distance between slots")]
    [SerializeField]
    private float slotDistance = 19;
    [Tooltip("Selected item")]
    [SerializeField]
    private InventorySlot selectedItem;

    [Header("Audio Configuration")]
    [Tooltip("Audio for the invetory selector movement")]
    [SerializeField]
    private AudioClip moveSelectorAudio;
    [Tooltip("Audio for selection")]
    [SerializeField]
    private AudioClip selectAudio;
    [Tooltip("Audio for item destruction")]
    [SerializeField]
    private AudioClip destroyItemAudio;
    [Tooltip("Audio for item creation")]
    [SerializeField]
    private AudioClip createItemAudio;

    SpriteAtlas ItemsAtlas;
    PlayerActions playerInput;
    object[] items;
    int selectorInventoryIndex
    {
        get { return GetInventoryIndex(selectedSlot); }
    }

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
        StopAllCoroutines();
        transform.DestroyAllChildrean();
        while (slots.Count < inventorySize.x * inventorySize.y)
        {
            GameObject newSlot = new GameObject("Inventory Slot");
            newSlot.transform.parent = transform;
            newSlot.transform.position = new Vector3();
            newSlot.transform.localScale = new Vector3(1, 1, 1);
            slots.Add(newSlot);
            slotsItems.Add(null);
        }

        for (int x = 0; x < slots.Count; x++)
        {
            int xPosition = (int)((x - x % inventorySize.x) / inventorySize.x);
            Vector2 xyPosition = new Vector2(x - xPosition * inventorySize.x, xPosition);

            InventorySlot slot = slots[x].AddComponent<InventorySlot>();
            slots[x].AddComponent<Image>();

            slot.inventoryPosition = xyPosition;
            slot.inventoryID = x;

            xyPosition.y *= -1;

            slots[x].transform.localPosition = slotPadding + xyPosition * slotDistance;
        }

        for (int x = 0; x < 5; x++)
        {
            int randomSlot = Random.Range(0, slots.Count);
            while (slotsItems[randomSlot] != null) randomSlot = Random.Range(0, slots.Count);

            slotsItems[randomSlot] = (InventoryItem)items[Random.Range(0, items.Length)];

            InventorySlot slot = slots[randomSlot].GetComponent<InventorySlot>();
            slot.slotItem = slotsItems[randomSlot];

            GameController.gc.audioSource.PlayOneShot(createItemAudio);
            StartCoroutine(slots[randomSlot].transform.AnimateScale(.15f, GameController.gc.popUpAnimationCurve));
        }

        ChangeSelection(new Vector2());
        UpdateInventory();
    }

    private void ChangeSelection(Vector2 xy)
    {
        selectedSlot += new Vector2(xy.x,-xy.y);
        selectedSlot.x = (int)Mathf.Repeat(selectedSlot.x, inventorySize.x);
        selectedSlot.y = (int)Mathf.Repeat(selectedSlot.y, inventorySize.y);

        int slotIndex = selectorInventoryIndex;
        
        selectorTransform.position = slots[slotIndex].transform.position;

        if (selectedItem == null)
        {
            if (slotsItems[slotIndex] != null) itemNameText.text = slotsItems[slotIndex].itemName;
            else itemNameText.text = "";
        }

        GameController.gc.audioSource.PlayOneShot(moveSelectorAudio);
    }

    private void SelectSlot()
    {
        selectorTransform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(selectorTransform.AnimateScale(.15f, GameController.gc.popInAnimationCurve));
        int slotIndex = selectorInventoryIndex;

        if (selectedItem != null)
        {
            InventoryItem itemToChangeSlot = slotsItems[slotIndex];
            InventorySlot slotToReciveItem = selectedItem;

            slotsItems[slotIndex] = selectedItem.GetComponent<InventorySlot>().slotItem;
            slots[slotIndex].GetComponent<InventorySlot>().slotItem = slotsItems[slotIndex];
            StartCoroutine(slots[slotIndex].transform.AnimateScale(.15f, GameController.gc.popUpAnimationCurve));

            slotToReciveItem.slotItem = itemToChangeSlot;
            slotsItems[selectedItem.inventoryID] = itemToChangeSlot;

            selectedItem = null;
            selectedSelectorTransform.gameObject.SetActive(false);
            pickedObjectIndicator.gameObject.SetActive(false);

        } else
        {
            if (slotsItems[slotIndex] != null)
            {
                selectedItem = slots[slotIndex].GetComponent<InventorySlot>();

                selectedSelectorTransform.gameObject.SetActive(true);

                pickedObjectIndicator.gameObject.SetActive(true);
                StartCoroutine(pickedObjectIndicator.transform.AnimateScale(.15f, GameController.gc.popUpAnimationCurve));

                pickedItemRepresentation.sprite = selectedItem.slotItem.itemSprite;

                selectedSelectorTransform.transform.position = selectedItem.transform.position;
            }
        }

        GameController.gc.audioSource.PlayOneShot(selectAudio);
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
            GameObject popOutAnimObject = Instantiate(slotToBeDeleted.gameObject, slotToBeDeleted.transform);
            popOutAnimObject.transform.localPosition = new Vector3();
            StartCoroutine(popOutAnimObject.transform.AnimateScale(.1f, GameController.gc.popOutAnimationCurve, false));
            selectedSelectorTransform.gameObject.SetActive(false);
            pickedObjectIndicator.gameObject.SetActive(false);

            GameController.gc.audioSource.PlayOneShot(destroyItemAudio);
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
                slotImage.enabled = true;
                slotImage.sprite = ItemsAtlas.GetSprite(slotsItems[x].itemSprite.name);
                slotImage.SetNativeSize();
            }
            else
            {
                slotImage.enabled = false;
            }
        }
    }

    private int GetInventoryIndex(Vector2 inventoryPosition)
    {
        float indexValue = selectedSlot.x + selectedSlot.y * inventorySize.x;
        return (int)indexValue;
    }
}
