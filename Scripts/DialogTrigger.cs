
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    void OnTriggerEnter()
    {
        print("Triggered");
        var dialogBox = FindObjectsOfType<Dialogue>(true);
        print("dialogBox is: " + dialogBox[0]);
        dialogBox[0].gameObject.SetActive(true);
    }
}
