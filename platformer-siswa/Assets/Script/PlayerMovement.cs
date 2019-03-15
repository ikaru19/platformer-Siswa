using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D rigidBody2D;
    private Transform groundCheck;

    void Awake()
    {
        groundCheck = transform.Find("groundCheck");
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        float xSpeed = xMove * speed;
        float ySpeed = yMove * speed;
        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
        rigidBody2D.velocity = newVelocity;
    }
}
