using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class StickyController : MonoBehaviour
{

    public Rigidbody2D Player;
    public float PlayerSpeed = 1;
    public float PlayerJumpSpeed = 1;
    public float RotateAngle = 90;
    public string GroundTag = "Ground";
    public bool UseGroundCheck = true;
    public bool CanJump = true;
    public bool CanJumpInAir = false;
    public bool CanMoveInAir = true;
    public bool UseArrows = false;

    public bool IsGrounded = true;

    // Update is called once per frame
    void Update()
    {
        // Get Axis
        var right = Input.GetKey(UseArrows ? KeyCode.RightArrow : KeyCode.D);
        var left = Input.GetKey(UseArrows ? KeyCode.LeftArrow : KeyCode.A);
        var jump = Input.GetKeyDown(UseArrows ? KeyCode.UpArrow : KeyCode.Space);

        // Rotate
        if (right && (CanMoveInAir || IsGrounded))
        {
            transform.rotation = new Quaternion();
            transform.Rotate(new Vector3(0, 0, RotateAngle * -1));
        }
        else if (left && (CanMoveInAir || IsGrounded))
        {
            transform.rotation = new Quaternion();
            transform.Rotate(new Vector3(0, 0, RotateAngle));
        }

        // TODO: JUMP
        if (jump && (CanJumpInAir || IsGrounded))
            Player.AddForce(new Vector2(0, PlayerJumpSpeed));


        // Move
        if ((right || left) && (CanMoveInAir || IsGrounded))
        Player.AddForce(new Vector2((right ? 1 : -1) * PlayerSpeed, 0));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("White");
        Debug.Log(collision.collider.gameObject.tag);
        if (collision.collider.gameObject.tag == GroundTag && UseGroundCheck) IsGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("NIGGAAA");
        if (collision.collider.gameObject.tag == GroundTag && UseGroundCheck) IsGrounded = false;
    }
}
