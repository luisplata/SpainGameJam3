using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;
    private Rigidbody2D rb2d;
    private Vector2 inputValue;
    private bool isJump;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isJump = false;
    }

    public void OnMovementPlayer(InputAction.CallbackContext value)
    {
        var readValue = value.ReadValue<Vector2>();
        if (readValue.y > 0.2f)
        {
            Jumping();
        }
        readValue.y = 0;
        inputValue = readValue;
    }

    private void Jumping()
    {
        if (isJump) return;
        isJump = true;
        rb2d.AddForce(Vector2.up * forceJump,ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJump = false;
        }
    }

    private void FixedUpdate()
    {
        var beforeVelocity = inputValue * Time.deltaTime * speed;
        beforeVelocity.y = rb2d.velocity.y;
        rb2d.velocity = beforeVelocity;
    }
}
