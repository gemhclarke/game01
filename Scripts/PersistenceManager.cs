using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager instance = null;
    public static PersistenceManager Instance;

    private void Awake()
    {     
        if (instance != null && instance != this){
            Destroy(this.gameObject);

        } else {
            instance = this;
        } 
        DontDestroyOnLoad(this.gameObject);
    }
}
