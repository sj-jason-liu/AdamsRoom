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
        Movement();
    }

    private void Movement()
    {
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        movement = new Vector3(moveHorizontal, 0f, 0f);
        velocity = movement * moveSpeed;

        Fliping(moveHorizontal);

        if (controller.isGrounded == true)
        {
            isJumping = false;
            anim.SetBool("isJumping", isJumping);
            anim.SetFloat("Running", Mathf.Abs(moveHorizontal));

            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                _yVelocity = _jumpHeight;
                isJumping = true;
                anim.SetBool("isJumping", isJumping);
                Debug.Log(controller.isGrounded);
            }
        }
        else
        {
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Fliping(float moveHorizontal)
    {
        if (moveHorizontal != 0)
        {
            bool isFliping = movement.x > 0 ? false : true;
            spriteRenderer.flipX = isFliping;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(controller.isGrounded == false && hit.transform.tag == "Ground")
        {
            _yVelocity -= _gravity;
        }
    }
}
