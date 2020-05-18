using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectField : MonoBehaviour
{

    public float intervalMin = 0.1f;
    public float intervalMax = 0.5f;
    public float numObjects = 5; 

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("SpawnObject", intervalMin); // call the function

    }

    void SpawnObject()
    {
        // generation
        for (int i = 0; i < numObjects; i++)
        {
            GameObject fallingObject = FallingObjectPool.instance.GetFallingObject();
        }

        // call the function again
        Invoke("SpawnObject", Random.Range(intervalMin, intervalMax));

    }

}
