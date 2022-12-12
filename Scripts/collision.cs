using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Patroller")
            {
                SceneManager.LoadScene("Game");
            }
    }
}
