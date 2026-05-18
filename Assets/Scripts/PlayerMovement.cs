using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public float speed = 2.5f;
    public float jumpForce = 3f;

    public Transform groundCheck;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Always turns x movement into a +ve number
        float absX = Mathf.Abs(myRigidbody2D.linearVelocityX);
        
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        myRigidbody2D.linearVelocityX = input.x * speed;
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded())
        {
            myRigidbody2D.linearVelocityY = jumpForce;
        }
    }

    private bool isGrounded()
    {
        // Boxcast towards the floor
        // Converts a collider to a true
        // or nothing to false

        return Physics2D.OverlapBox(
            groundCheck.position,
            new Vector2(0.1f, 0.05f),
            0);
    }


}

