using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    private bool facingRight = true;
    
    void Awake() {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(playerController.move));
        animator.SetBool("grounded", playerController.grounded);
    }

    void FixedUpdate() {
        if (playerController.move < -0.1 && facingRight) {
            Flip();
        }
        if (playerController.move > 0.1 && !facingRight) {
            Flip();
        }
    }

    private void Flip()
	{
		facingRight = !facingRight;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
