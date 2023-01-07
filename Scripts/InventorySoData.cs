using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventorySoData : ScriptableObject
{
    //[SerializeField]
    //private Item[] items;
    public List<Item> persistedItems = new List<Item>();

    
    public List<Item> GetItems()
    {
        return persistedItems;
    }

   public void SetItem(Item item){
        persistedItems.Add(item);
   }
}
