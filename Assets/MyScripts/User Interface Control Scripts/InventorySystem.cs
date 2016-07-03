using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    private GameObject[] inventorySlots;
    private List<GameObject> itemsInInventory = new List<GameObject>();
    private ControlItemProperties controlItemProperties;
    private bool inventoryScanned = false;

    public Text inventorySpaceTxt;

    void Awake()
    {
        inventorySlots = GameObject.FindGameObjectsWithTag("InventorySlot");
        controlItemProperties = GameObject.FindObjectOfType<ControlItemProperties>();       
    }

    void Start()
    {
        InventorySpaceTxtUpdater();
    }

    void Update()
    {
        if(!inventoryScanned)
        {
            ScanInventory();
        }
    }

    private void InventorySpaceTxtUpdater()
    {
        inventorySpaceTxt.text = itemsInInventory.Count.ToString() + "/" + ScanInventory().Count.ToString();
    }

    private List<GameObject> ScanInventory()                         // Scanning whole inventory slots and returns slot gameObject.
    {
        List<GameObject> slotList = new List<GameObject>();
        foreach (GameObject slot in inventorySlots)
        {
            slotList.Add(slot.transform.gameObject);        
        }
        inventoryScanned = true;
        return slotList;
    }
    
    public void AddItemToInventory(GameObject item)
    {
        itemsInInventory.Add(item);                                 // Adds item into item list.
        InventorySpaceTxtUpdater();
        GameObject freeInventorySlot;                               // New gameobject variable to store first free slot gameobject.

        foreach (GameObject slot in ScanInventory())                // Searches for free inventory slot.
        {
            if (slot.transform.childCount == 0)                     // if slot gameobject has 0 children therefore it's free.
            {
                freeInventorySlot = slot;                           // applys first free slot gameobject to new gameobject.
                                                                    // Following code prepares item for the inventory. I render real gameobject meshes for inventory.
                Destroy(item.GetComponent<Rigidbody>());

                if (item.GetComponent<BoxCollider>() == true)       // Handeling 2 types of colliders.
                {
                    Destroy(item.GetComponent<BoxCollider>());
                }
                else
                {
                    Destroy(item.GetComponent<CapsuleCollider>());
                }
                
                item.transform.SetParent(freeInventorySlot.transform);
                item.transform.position = freeInventorySlot.transform.position;
                item.transform.rotation = freeInventorySlot.transform.rotation;

                item.GetComponent<MeshRenderer>().shadowCastingMode
                    = UnityEngine.Rendering.ShadowCastingMode.Off;

                item.transform.localScale = new Vector3(freeInventorySlot.transform.localScale.x + 30, 
                    freeInventorySlot.transform.localScale.y + 30,
                    freeInventorySlot.transform.localScale.z + 30);

                item.gameObject.layer = LayerMask.NameToLayer("inventoryItem");
            }
        }     
    }

    public void DropItem(GameObject draggingItem, GameObject currentSlot)
    {
        itemsInInventory.Remove(draggingItem);
        controlItemProperties.RestoreGameObjectProperties(draggingItem, currentSlot);
        InventorySpaceTxtUpdater();
    }
}