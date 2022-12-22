using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag) 
        {
            case "Patroller":
                Debug.Log("Collided with Patroller");
                //SceneManager.LoadScene("Game");
                break;
            case "RedKey":
                Debug.Log("Collided with Redkey");
                break;
        }
    }

    void OnCollisionStay(Collision other)
    {
        switch (other.gameObject.tag) 
        {
            case "RedKey":
                Debug.Log("Adjacent to Redkey");
                break;
        }

    }
}
