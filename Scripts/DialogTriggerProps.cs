using UnityEngine;


[CreateAssetMenu(fileName = "New Trigger Props", menuName = "Dialog/TriggerPropeties")]

public class DialogTriggerProps : ScriptableObject
{
    new public string name;
    public string[] lines;
}
