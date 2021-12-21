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
        // convert mouse position to worldposition
        Vector3 position = Input.mousePosition;
        position.z = -Camera.main.transform.position.z;
        position = Camera.main.ScreenToWorldPoint(position);

        // move character to mouse position and clamp in screen
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
        else if (position.y + colliderHalfHeight > ScreenUtils.ScreenTop)
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
