using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public float speed = 3f;
    public float jumpForce = 3f;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public ParticleSystem walkingParticles;

    public Transform groundCheck;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        // Always turns x movement into a +ve number
        float absX = Mathf.Abs(myRigidbody2D.linearVelocityX);
        animator.SetFloat("yVelocity", myRigidbody2D.linearVelocityY);
        animator.SetBool("Grounded", isGrounded());

        if (walkingParticles == null)
        {
            return;
        }

        if (isGrounded() && !walkingParticles.isPlaying)
        {
            walkingParticles.Play();
        }

        if (!isGrounded() && walkingParticles.isPlaying)
        {
            walkingParticles.Stop();
        }
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        myRigidbody2D.linearVelocityX = input.x * speed;
        if (input.x != 0)
        {
            animator.SetBool("IsRunning", true);
            spriteRenderer.flipX = input.x < 0;
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
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

