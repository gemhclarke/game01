using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; // Make this a static object (i.e a singleton)
    
    GameObject inventoryUI;
    InventorySlot[] inventorySlots;
    public List<Item> Items = new List<Item>(); // Initialise the Inventory Database
    int inventorySlotsCount;

    void Start()
    {
        instance = this; // Related to making this a singleton (see above)
        inventoryUI = this.gameObject; // This is a reference to the Inventory UI 
        inventorySlots = inventoryUI.transform.GetComponentsInChildren<InventorySlot>(true);
        inventorySlotsCount = inventorySlots.Length;
    }

    public void Add(Item item)
    { 
        // Add the item to the Inventory database
        print("Adding item " + item.name + " to Inventory database");
        Items.Add(item);

        // Add the item to the Inventory UI
        int slot = getFreeInventorySlot();
        print("Adding item " + item.name + " to Inventory UI at slot: " + slot);
        inventorySlots[slot].AddItem(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    private int getFreeInventorySlot()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            var slotName = inventorySlots[i].name;
            bool hasItem =  inventorySlots[i].hasItem;
            if (!hasItem) 
            {
                return i;
            }
        }
        return 100; // Adding this temporarilty to indicate no more slots available 
    }
}
