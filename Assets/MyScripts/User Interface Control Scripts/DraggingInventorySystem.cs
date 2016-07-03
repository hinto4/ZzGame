using UnityEngine;
using System.Collections;

/*

Thinking about new design so Dragging system doesn't depend on inventory so i can use same system somewhere else aswell. Same goes for inventory.
I want everything independent to make classes reusable.

    */

public class DraggingInventorySystem : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private UnderMouseDetection underMouseDetectionSystem;
    private GameObject currentSlot;
    private GameObject draggingItem;

    public GameObject DropZone;

    void Awake()
    {
        inventorySystem = GameObject.FindObjectOfType<InventorySystem>();
    }
    
    void Start()
    {      
        underMouseDetectionSystem = GameObject.FindObjectOfType<UnderMouseDetection>();
    }
    public void OnItemDrag()
    {
        currentSlot = underMouseDetectionSystem.UnderMouse();                   // stores collider of the slo under the mouse.
        if (currentSlot.transform.childCount > 0)                               // Something is in the slot.
        {
            GameObject item = currentSlot.transform.GetChild(0).gameObject;     // Get's item that's in the slot.
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            mousePos.z = 0.4f;

            if (item.tag == "Item" || item.tag == "WoodenStick")                                             // If it's item that's being dragged, allow drag
            {
                draggingItem = item;
                draggingItem.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            }
        }
        else if (currentSlot.transform.gameObject == DropZone && draggingItem != null)  // Handles the item drop.
        {
            inventorySystem.DropItem(draggingItem, currentSlot);
        }
        else
        {
            if (draggingItem != null)
            {
                draggingItem.transform.SetParent(currentSlot.transform);
            }
        }
    }

    public void OnItemDragEnd()                                                 // Resets the dragged item to the slot position and it's position.
    {
        if (draggingItem != null)
        {
            draggingItem.transform.position = currentSlot.transform.position;
            draggingItem = null;
        }
    }

    private void ScanForDraggableItem()                 // There will be a lot of items, lets scan for a draggable item tag.
    {

    }
}