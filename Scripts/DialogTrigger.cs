
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{  
    // We declare our DialogTriggerProps here and then drag the corresponding 
    // ScriptableObject in the inspector
    public DialogTriggerProps DialogText; 
    void OnTriggerEnter()
    {
        var dialogArray = FindObjectsOfType<Dialogue>(true); // Get a reference to the Dialog object
        var dialog = dialogArray[0];
        dialog.gameObject.SetActive(true); // Show the Dialog box on screen
        dialog.lines = DialogText.lines; // Set the text to that which we've set in our ScriptableObject
    }
}
