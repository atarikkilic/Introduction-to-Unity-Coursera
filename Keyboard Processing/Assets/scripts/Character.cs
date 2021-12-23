using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A character
/// </summary>
public class Character : MonoBehaviour
{
    // saved for efficiency
    float colliderHalfWidth;
    float colliderHalfHeight;

    // movement support

    const float MoveUnitsPerSecond = 5;


    /// <summary>
    ///  Use this for initialization
    /// </summary>
    
    void Start()
    {
        //save for efficiency
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        colliderHalfWidth = collider.size.x / 2;
        colliderHalfHeight = collider.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // move based on input
        Vector3 position = transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            position.x += MoveUnitsPerSecond * horizontalInput * Time.deltaTime;
        }

        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput != 0)
        {
            position.y += MoveUnitsPerSecond * verticalInput * Time.deltaTime;
        }

        // move character to new position and clamp in screen
        transform.position = position;
        ClampInScreen();
    }

    /// <summary>
    ///  Clamps the character in the screen
    /// </summary>
    void ClampInScreen()
    {
        // clamp position as necessary
        Vector3 position = transform.position;
        if (position.x - colliderHalfWidth < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        else if (position.x + colliderHalfWidth > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenRight - colliderHalfWidth;
        }
        if (position.y + colliderHalfHeight > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenTop - colliderHalfWidth;
        }
        else if (position.y + colliderHalfHeight < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenBottom + colliderHalfWidth;
        }

        transform.position = position;
    }
}
