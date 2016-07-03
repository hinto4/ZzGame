using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Eyes : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private Camera eyes;
    private float defaultFOV;

    public GameObject pickUpHand;
   
    void Awake()
    {
        inventorySystem = GameObject.FindObjectOfType<InventorySystem>();
    }

    void Start()
    {
        eyes = GetComponent<Camera>(); 
        defaultFOV = eyes.fieldOfView;
    }

    void Update()
    {
        ZoomInput();
        OnFindPickupableTargetAhead();
    }

    void OnFindPickupableTargetAhead()                                       
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2))
        {
            if (hit.collider != null)
            {
                if(hit.collider.tag == "Item" || hit.collider.tag == "WoodenStick")                                  // Detects item that's pickupable.
                {
                    pickUpHand.SetActive(true);

                    GameObject Item = hit.transform.gameObject;                 // Item that was hit.
                    if(Input.GetButtonDown("Interact"))
                    {
                        inventorySystem.AddItemToInventory(Item);
                    }
                }
                else
                {
                    pickUpHand.SetActive(false);                                // Temporary, working on better solution.
                }
            }
            else
            {
                pickUpHand.SetActive(false);                                    // Temporary, working on better solution.
            }
        }
    }

    private void ZoomInput()
    {
        if (Input.GetButton("Zoom"))
        {
            eyes.fieldOfView = defaultFOV / 1.5f;
        }
        else
        {
            eyes.fieldOfView = defaultFOV;
        }
    }
}