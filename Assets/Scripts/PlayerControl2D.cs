using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2D : MonoBehaviour
{
    public float moveSpeed = 5f;  // The speed at which the player moves

    private CharacterController controller;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private Vector3 movement, velocity;

    [SerializeField]
    private float _gravity = 1f;
    [SerializeField]
    private float _jumpHeight = 15f;
    private float _yVelocity;

    private bool isJumping;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        if(controller.isGrounded)
        {
            movement = new Vector3(moveHorizontal, 0f, 0f);
            velocity = movement * moveSpeed;
            anim.SetFloat("Running", Mathf.Abs(moveHorizontal));

            if (moveHorizontal != 0)
            {
                bool isFliping = movement.x > 0 ? false : true;
                spriteRenderer.flipX = isFliping;
            }

            if(isJumping)
            {
                isJumping = false;
                anim.SetBool("isJumping", isJumping);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity += _jumpHeight;
                isJumping = true;
                anim.SetBool("isJumping", isJumping);
            }
        }
        else
        {
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        controller.Move(velocity * Time.deltaTime);
    }
}
