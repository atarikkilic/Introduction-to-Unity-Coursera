using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Drives the game object based on keyboard input
/// </summary>
public class Driver : MonoBehaviour
{
    const float MoveUnitsPerSecond = 5;
   
    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        // move horizontally as appropriate
        float horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput != 0)
        {
            position.x += horizontalInput * MoveUnitsPerSecond * Time.deltaTime;
        }

        // move vertically as appropriate
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput != 0)
        {
            position.y += verticalInput * MoveUnitsPerSecond * Time.deltaTime;
        }

        // move character to new position
        transform.position = position;
    }
}
