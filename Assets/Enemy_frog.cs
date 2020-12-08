using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_frog : Enemy
{
    private Rigidbody2D rb;
    // private Animator anim;
    private Collider2D coll;
    public LayerMask ground;
    public Transform leftPoint, rightPoint;
    private float leftPointX, rightPointX;
    public float speed, jumpForce;

    private bool faceLeft = true;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

        transform.DetachChildren();
        leftPointX = leftPoint.position.x;
        rightPointX = rightPoint.position.x;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }

    void Update()
    {
        //Movement();
        SwitchAnim();
    }

    void Movement()
    {
        // 青蛙移动，如果面朝左，就朝左移动，移动到leftPoint的时候朝右移动
        if (faceLeft)
        {
            // 在地面上的时候才跳
            if (coll.IsTouchingLayers(ground))
            {
                anim.SetBool("jumping", true);
                rb.velocity = new Vector2(-speed, jumpForce);
            }
            
            if (transform.position.x < leftPointX) // 超过左侧点掉头
            {
                transform.localScale = new Vector3(-1, 1, 1);
                faceLeft = false;
            } 
        } else
        {
            // 在地面上的时候才跳
            if (coll.IsTouchingLayers(ground))
            {
                anim.SetBool("jumping", true);
                rb.velocity = new Vector2(speed, jumpForce);
            }

            if (transform.position.x > rightPointX) // 超过右侧点掉头
            {
                transform.localScale = new Vector3(1, 1, 1);
                faceLeft = true;
            }
        }
    }

    void SwitchAnim()
    {
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0.1)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        if (coll.IsTouchingLayers(ground) && anim.GetBool("falling"))
        {
            anim.SetBool("falling", false);
        }
    }
}
