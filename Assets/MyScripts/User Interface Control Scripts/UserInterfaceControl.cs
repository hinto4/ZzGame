using UnityEngine;
using System.Collections;

public class UserInterfaceControl : MonoBehaviour
{
    private GameObject inGameMenu;
    private GameObject inventorySystem;

    public bool isPanelActive = false;      // Send to FPSController, disable mouse look while interacting with menu.
    
    void Start()
    {
        inGameMenu = GameObject.FindGameObjectWithTag("InGameMenu");
        inventorySystem = GameObject.FindGameObjectWithTag("InventorySystem");

        inGameMenu.gameObject.SetActive(false);
        inventorySystem.gameObject.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        ButtonBehaviour("Inventory", inventorySystem);
        ButtonBehaviour("InGameMenu", inGameMenu);

        if(Input.GetKeyDown(KeyCode.Mouse0) && isPanelActive == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void ButtonBehaviour(string getButton, GameObject gameObjectName)
    {
        if (Input.GetButtonDown(getButton) && isPanelActive == false) 
        {
            gameObjectName.gameObject.SetActive(true);
            isPanelActive = true;
            Cursor.visible = true;           
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetButtonDown(getButton) && isPanelActive == true)
        {
            gameObjectName.gameObject.SetActive(false);
            isPanelActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}