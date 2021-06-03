using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tested with:
///     Rigedbody2d:
///         Mass: 1
///         Lin Drag: 10
///         Z : Frozen
///         ... - 0
/// </summary>
public class PlayerFreeController : MonoBehaviour
{
    public Rigidbody2D Player;
    public float PlayerSpeed = 1;

    // Update is called once per frame
    void Update()
    {

        // Get Axis
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        // Debug
        Debug.Log($"HORIZONTAL AXIS: {h}");

        // Rotate
        if (h > 0)
        {
            transform.rotation = new Quaternion();
            transform.Rotate(new Vector3(0, 0, -90));
        }
        else if (h < 0)
        {
            transform.rotation = new Quaternion();
            transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (v > 0)
        {
            transform.rotation = new Quaternion();
        }
        else if (v < 0)
        {
            transform.rotation = new Quaternion();
            transform.Rotate(new Vector3(0, 0, 180));
        }

        // Move
        if (h != 0) 
            Player.AddForce(new Vector2(h * PlayerSpeed, 0));

        if (v != 0)
            Player.AddForce(new Vector2(0, v * PlayerSpeed));
    }
}
