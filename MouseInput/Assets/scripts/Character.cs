using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A character
/// </summary>
public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // convert mouse position to worldposition
        Vector3 position = Input.mousePosition;
        position.z = -Camera.main.transform.position.z;
        position = Camera.main.ScreenToWorldPoint(position);

        gameObject.transform.position = position;
    }
}
