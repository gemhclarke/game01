using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickRedKey : MonoBehaviour
{

    public Item item;
    public Component doorcollider;
    public GameObject keygone;
    
    void OnTriggerStay()
    {
        if(Input.GetKey(KeyCode.E)){
            doorcollider.GetComponent<BoxCollider> ().enabled=true;
            keygone.SetActive (false);
        }
    }
}
