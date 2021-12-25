using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Vector2 position;
    Rigidbody2D shipRigidbody;
    Vector2 thrustDirection = new Vector2 (1,0);
    const float ThrustForce = 3;
    CircleCollider2D shipCollider;
    float shipColliderRadius;
    const float RotateDegreesPerSecond = 10;

    // Start is called before the first frame update
    void Start()
    {
        shipRigidbody = GetComponent<Rigidbody2D>();
        shipCollider = GetComponent<CircleCollider2D>();
        shipColliderRadius = shipCollider.radius;
    }

    // Update is called once per frame
    void Update()
    {
        
        // calculate rotation amount and apply rotation
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {
            if (rotationInput < 0)
            {
            rotationAmount *= -1;
            }

            // change thrust direction applied to the ship to move it in the direction 
            transform.Rotate(Vector3.forward, rotationAmount);
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }
        
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

    /// <summary>
    /// Called when the ship becomes invisible
    /// </summary>
    void OnBecameInvisible()
    {
        // check right, left, bottom, and top sides
        if (position.x - shipColliderRadius <= ScreenUtils.ScreenLeft)
		{
			position.x = ScreenUtils.ScreenRight + shipColliderRadius;
		}

		else if (position.x + shipColliderRadius >= ScreenUtils.ScreenRight)
		{
			position.x = ScreenUtils.ScreenLeft - shipColliderRadius;
		}
        if (position.y + shipColliderRadius >= ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenBottom - shipColliderRadius;
        }

        else if (position.y - shipColliderRadius <= ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenTop + shipColliderRadius;
        }

        
        transform.position = position;
    }
}
