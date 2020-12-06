using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_frog : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform leftPoint, rightPoint;
    private float leftPointX, rightPointX;
    public float speed;

    private bool faceLeft = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        leftPointX = leftPoint.position.x;
        rightPointX = rightPoint.position.x;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // 青蛙移动，如果面朝左，就朝左移动，移动到leftPoint的时候朝右移动
        if (faceLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < leftPointX)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                faceLeft = false;
            } 
        } else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightPointX)
            {
                transform.localScale = new Vector3(1, 1, 1);
                faceLeft = true;
            }
        }
    }
}
