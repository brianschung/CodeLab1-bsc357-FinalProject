using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{

    public float xPosRange;

    const float MIN_SPEED = 0.02f; //min speed
    const float MAX_SPEED = 0.15f; //max speed
    const float MAX_Y = 8; //where to start object
    const float MIN_Y = -8; //where to recycle object

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        speed = -Random.Range(MIN_SPEED, MAX_SPEED); // set its new speed
        transform.position = new Vector2(Random.Range(-xPosRange, xPosRange),MAX_Y); // set its new position
        transform.rotation = Random.rotation; // set its new rotation
    }


    // Update is called once per frame
    void Update()
    {
        // move the object
        transform.position = new Vector2(transform.position.x, transform.position.y + speed);

        // recycle the object if the star falls below position
        if (transform.position.y < MIN_Y)
        {
            FallingObjectPool.instance.Push(gameObject); //recycle it into the pool
        }
    }
}
