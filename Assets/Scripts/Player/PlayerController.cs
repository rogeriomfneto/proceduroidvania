using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float runSpeed = 7f;

    [SerializeField]
    private float jumpForce = 20f;

    public float move;

    private bool jumpPressed;

    public bool grounded = true;

    [SerializeField]
    private Transform groundReference;

    [SerializeField]
    private LayerMask groundLayer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetButton("Jump");

    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundReference.position, .2f, groundLayer);
        Move(move);
        Jump(jumpPressed);
    }

    public void Move(float move)
    {
        rb.velocity = new Vector2(move * runSpeed, rb.velocity.y);
    }

    public void Jump(bool jumpPressed)
    {
        if (jumpPressed && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
