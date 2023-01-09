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
        
        // Because the Inventory IU is disabled at the start our InventoryManager is not initialized
        // which causes null pointer exceptions if we try to pick up something before we've looked at out inventory
        // To work around this we need to enable hen disable the Inventory UI. The enable part instantiates 
        // the InventoryManager.
        inv[0].gameObject.SetActive(true);
        inv[0].gameObject.SetActive(false);
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
        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        //     GameState newGameState = currentGameState == GameState.GamePlay ? GameState.Paused : GameState.GamePlay;
        //     GameStateManager.Instance.SetState(newGameState);
        // }
    }
}
