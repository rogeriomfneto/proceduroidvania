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

    public bool shootPressed;

    public bool grounded = true;

    [SerializeField]
    private Transform groundReference;
    
    [SerializeField]
    private Transform shotReference;

    [SerializeField]
    private ShotController shot;

    [SerializeField]
    private LayerMask groundLayer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")) {
            jumpPressed = true;
        }

        if (Input.GetButtonDown("Fire1")) {
            shootPressed = true;
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundReference.position, .2f, groundLayer);
        Move(move);
        Jump(jumpPressed);
        Shoot(shootPressed);
        
        releaseButtons();
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

     public void Shoot(bool shootPressed)
    {
        if (shootPressed)
        {
            Instantiate(shot, shotReference.position, shotReference.rotation).direction = transform.localScale.x;
            
        }
    }

    private void releaseButtons() {
        jumpPressed = false;
        shootPressed = false;
    }
}
