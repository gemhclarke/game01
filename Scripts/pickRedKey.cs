using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickRedKey : MonoBehaviour
{

    public Component doorcollider;
    public GameObject keygone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        if(Input.GetKey(KeyCode.E))
       doorcollider.GetComponent<BoxCollider> ().enabled=true;

       if(Input.GetKey(KeyCode.E))
       keygone.SetActive (false);
    }
}
