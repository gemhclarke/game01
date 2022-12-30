using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener : MonoBehaviour
{
    InventoryManager[] inv;
    //mouseMovement[] mm;

    void Start()
    {
        //Get a reference to our InvdentoryManager
        inv = Resources.FindObjectsOfTypeAll<InventoryManager>();

        // Get a reference to the MouseMovement script
        //mm = Resources.FindObjectsOfTypeAll<mouseMovement>();


        
    }

    void Update()
    {
        // Show/Hide inventory
        if (Input.GetKeyDown("escape")){
            var igo = inv[0].gameObject;
            //var mmgc = mm[0].gameObject.GetComponent<mouseMovement>();
            if (igo.activeSelf){
                igo.SetActive(false);
                //mmgc.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Resources.FindObjectsOfTypeAll<mouseMovement>()[0].gameObject.GetComponent<mouseMovement>().enabled=true;
            } else {
                igo.SetActive(true);
                //mmgc.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Resources.FindObjectsOfTypeAll<mouseMovement>()[0].gameObject.GetComponent<mouseMovement>().enabled=false;

            }
        }
    }
}
