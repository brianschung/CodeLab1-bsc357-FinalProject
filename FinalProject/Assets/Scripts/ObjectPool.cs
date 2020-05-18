using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{

    //Stack for holding GameObjects
    protected Stack<GameObject> pool = new Stack<GameObject>();

    //Get a GameObject
    public GameObject Get()
    {
        GameObject result; // variable for the GameObject
        if (pool.Count == 0) // if the pool is empty
        {
            result = GetNewObject(); // create a new object
        }
        else
        {
            result = pool.Pop(); // get an object from the stack
            print("Num Objects:  " + transform.childCount + " Pool Size: " + pool.Count);
        }

        result.transform.parent = this.transform; // object becomes child of pool GameObject

        result.SetActive(true); // set object active
        return result; // returns the object itself
    }

    // all children implements this or is a subclass
    protected abstract GameObject GetNewObject();

    // pushes GameObject into pool
    public void Push(GameObject used)
    {
        used.SetActive(false); // set object inactive
        pool.Push(used); // sets object into stack, to be reused
    }
}