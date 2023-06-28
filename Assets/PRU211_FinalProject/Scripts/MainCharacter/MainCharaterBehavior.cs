using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainCharaterBehavior : MonoBehaviour          //JUMP, RUN, WALLJUMPING
{
    Rigidbody2D bodyMainCharacter;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpPower;
    private float horizontal;
    private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private LayerMask wallLayer;
    [SerializeField]
    private float wallJumpCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        bodyMainCharacter = GetComponent<Rigidbody2D>();
        speed = 10;
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        jumpPower = 20;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        anim.SetBool("run", horizontal != 0);
        anim.SetBool("grounded", isGrounded());

        if (wallJumpCoolDown > 0.2f)
        {
            bodyMainCharacter.velocity = new Vector2(horizontal * speed, bodyMainCharacter.velocity.y);
            if (onWall() && !isGrounded())
            {
                bodyMainCharacter.gravityScale = 0;
                bodyMainCharacter.velocity = Vector2.zero;
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    Down();
                }
            }
            else
            {
                bodyMainCharacter.gravityScale = 7;
            }
            if (Input.GetKey(KeyCode.Space))
                jump();
        }
        else
            wallJumpCoolDown += Time.deltaTime;
    }

    private void jump()
    {
        if (isGrounded())
        {
            anim.SetTrigger("jump");
            bodyMainCharacter.velocity = new Vector2(bodyMainCharacter.velocity.x, jumpPower);
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontal == 0)
            {
                bodyMainCharacter.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 5, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            }
            else
                bodyMainCharacter.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCoolDown = 0;
        }
    }
    public bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    private void Down()
    {
        bodyMainCharacter.gravityScale = 10;
        bodyMainCharacter.velocity = new Vector2(bodyMainCharacter.velocity.x, -10);
    }

    public bool canAttack()
    {
        return (!onWall() && isGrounded());
    }


}
