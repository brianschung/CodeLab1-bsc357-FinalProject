using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extends abstract ObjectPool
public class FallingObjectPool : ObjectPool
{
    
    public GameObject fallingObject;
    public static FallingObjectPool instance;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this; // set instance to be this object
            DontDestroyOnLoad(gameObject); // don't destroy this object when loading a new scene
        }
        else
        {
            Destroy(gameObject); // if this object exists already, destroy (so that there's only 1 total)
        }
    }

    // abstract override
    protected override GameObject GetNewObject()
    {
        return Instantiate<GameObject>(fallingObject);
    }

    // wrapper around "Get" from the base
    public GameObject GetFallingObject()
    {
        GameObject recycledObject = Get(); // object out of stack
        recycledObject.GetComponent<FallingObjectScript>().Reset(); // reset the object
        return recycledObject; // return the object
    }

}
