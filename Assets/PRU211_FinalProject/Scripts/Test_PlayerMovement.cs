using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float climbSpeed = 3f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isClimbing = false;
    private bool canJump = true; // Biến để kiểm tra xem nhân vật có thể nhảy hay không

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (isClimbing)
        {
            rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * climbSpeed);
        }
        else
        {
            if (rb.velocity.y < 0) // Kiểm tra nếu nhân vật đang rơi xuống
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) // Kiểm tra nếu nhân vật nhảy nhưng không giữ nút nhảy
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && canJump) // Kiểm tra nếu nhấn phím Jump và có thể nhảy
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false; // Đánh dấu là không thể nhảy nữa cho đến khi rơi xuống đất
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.gravityScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.gravityScale = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Kiểm tra va chạm với đất
        {
            canJump = true; // Cho phép nhân vật nhảy lại
        }
    }
}
