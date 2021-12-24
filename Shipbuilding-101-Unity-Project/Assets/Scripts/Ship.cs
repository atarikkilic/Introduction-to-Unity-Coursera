using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Vector2 position;
    Rigidbody2D shipRigidbody;
    Vector2 thrustDirection = new Vector2 (1,0);
    const float ThrustForce = 3;

    // Start is called before the first frame update
    void Start()
    {
        shipRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //For physics-based actions
    void FixedUpdate()
    {
        position = transform.position;
        float thrustAxis = Input.GetAxis("Thrust");
        if(thrustAxis != 0)
        {
            shipRigidbody.AddForce(position + ThrustForce * thrustDirection * Time.deltaTime);
        }
    }
}
