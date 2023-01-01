
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public UnityEngine.Sprite icon = null;

    public UnityEngine.Sprite GetIcon()
    {
        return icon;
    }

}

