using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    void Start()
    {
        instance = this;
    }

}
