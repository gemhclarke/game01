using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; // Make this a static object (i.e a singleton)
    
    GameObject inventoryUI;

    void Start()
    {
        instance = this;
        inventoryUI = gameObject;
        print(inventoryUI);
    }




}
