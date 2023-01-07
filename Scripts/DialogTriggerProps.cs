using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New dialog props", menuName = "Dialog/properties")]
public class DialogTriggerProps : ScriptableObject
{
    new public string name;
    public string[] lines;
}
