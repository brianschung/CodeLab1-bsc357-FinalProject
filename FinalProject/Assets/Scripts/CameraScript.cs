using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // start and end positions
    public Transform startPos;
    public Transform endPos;

    public float speed = 1.0f; // units per second

    private float startTime; // time when movement started
    private float distance; // total distance

    // Start is called before the first frame update
    void Start()
    {

        startTime = Time.time; // set the starting time
        distance = Vector3.Distance(startPos.position, endPos.position); // calculate the total distance to travel
        
        //transform.position = new Vector3(0,10.0f,-10);
    }

    // Update is called once per frame
    void Update()
    {

        float distanceCovered = (Time.time - startTime) * speed; // set the distance covered to be the elapsed time multiplied by the speed.
        float fractionOfDistance = distanceCovered / distance; // calculate the fraction of distance covered.
        transform.position = Vector3.Slerp(startPos.position, endPos.position, fractionOfDistance*20); // set the position of the camera as a fraction of the distance between the two spots. 

        
        //if (transform.position.y > 0)
        {
            //transform.position -= new Vector3(0, 0.05f,0);
        }
    }
}
