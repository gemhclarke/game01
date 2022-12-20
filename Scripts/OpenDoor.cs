using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animation hinge;
    public Component doorcollider;

    void OnTriggerStay()
    {
        if(Input.GetKey(KeyCode.E))
        {
            hinge.Play();
            doorcollider.GetComponent<BoxCollider> ().enabled = false;
        }
    }
}
