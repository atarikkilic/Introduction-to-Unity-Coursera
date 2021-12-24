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
        if (position.x - shipColliderRadius <= ScreenUtils.ScreenLeft)
		{
			position.x = ScreenUtils.ScreenRight + shipColliderRadius;
		}

		else if (position.x + shipColliderRadius >= ScreenUtils.ScreenRight)
		{
			position.x = ScreenUtils.ScreenLeft - shipColliderRadius;
		}

        transform.position = position;
    }
}
