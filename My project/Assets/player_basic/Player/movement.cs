using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
 
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private Vector2 moveDirection;
    public Vector2 lastForward;

    bool canDash = true;
    public float dashSpeed;

    public float dashDuration;
    float dashTimePast = 0;

    float timePassed = 0;
    public float dashCooldown;

    bool isDashing = false;

    //this is a comment for player movement


    void Update()
    {

        //Count up with dashTimePast variable

        //If dashTimePast is greater than dashDuration, end the dash



        //Time.deltaTime is the time between frames

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;


        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);

        if (moveX < 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;

            
        }
        if (moveDirection.sqrMagnitude >= 1)
        {
            lastForward = moveDirection;

        }



        if (!isDashing)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }

        if (isDashing)
        {
            canDash = false;
            rb.velocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
            dashTimePast += Time.deltaTime;
            if (dashTimePast > dashDuration)
            {
                isDashing = false;
            }
        }
        else if (!canDash)
        {
            dashTimePast += Time.deltaTime;
            if (dashTimePast > dashCooldown)
            {
                dashTimePast = 0;
                canDash = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && canDash)
        {
            isDashing = true;

        }
    }
   
}
