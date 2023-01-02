using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public bool hasItem = false;

    public void AddItem(Item item)
    { 
        this.item = item;
        hasItem = true;
        print("Item name=" + item.name + " item icon=" + item.GetIcon());
        var image = gameObject.transform.GetComponentsInChildren<Image>(true);
        print("Image="+image[0]);
        image[0].sprite = item.GetIcon();
        image[0].enabled = true;
    }
}
