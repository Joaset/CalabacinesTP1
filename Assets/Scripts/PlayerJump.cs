using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    private Rigidbody2D ridgiBody;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform checker;
    public float radioChecker;
    private AudioSource jumpSound;

    void Start()
    {
        ridgiBody = GetComponent<Rigidbody2D>();
        jumpForce = 11f;
        radioChecker = 0.1f;
        jumpSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        Jump();
        isGrounded = Physics2D.OverlapCircle(checker.position,radioChecker,ground);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            ridgiBody.velocity = new Vector2(ridgiBody.velocity.x, jumpForce);
            jumpSound.Play();
        }
    }
}
