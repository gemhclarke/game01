using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public Component doorcollider;
    public GameObject keygone;
    
    void OnTriggerStay() // Triggered when we're inside the collider radius
    {
        if(Input.GetKey(KeyCode.E))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        InventoryManager.instance.Add(item);                    // Call the Add method on our InventoryManager singleton
        doorcollider.GetComponent<BoxCollider>().enabled=true;  // Enable the relevant door collider to we can open it now we have the key
        keygone.SetActive (false);                              // Make the key dissapear (because we've picked it up)
        Debug.Log("Picked up: "+item.name);
    }
}
