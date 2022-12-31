using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener : MonoBehaviour
{
    InventoryManager[] inv;

    void Start()
    {
        //Get a reference to our InvdentoryManager
        inv = Resources.FindObjectsOfTypeAll<InventoryManager>();
    }

    void Update()
    {
        // -----------------------------------------------------------------
        // Show/Hide inventory
        // -----------------------------------------------------------------
        if (Input.GetKeyDown("escape")){
            var igo = inv[0].gameObject;
            if (igo.activeSelf){
                igo.SetActive(false); // Hide Inventory
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Resources.FindObjectsOfTypeAll<mouseMovement>()[0].gameObject.GetComponent<mouseMovement>().enabled=true; // Enable player mouse control
            } else {
                igo.SetActive(true); // Display Inventory
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Resources.FindObjectsOfTypeAll<mouseMovement>()[0].gameObject.GetComponent<mouseMovement>().enabled=false; // Disable player mouse control
            }
        }
    }
}
