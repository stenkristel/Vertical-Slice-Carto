using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody rb;
    public Animator animator;

    public string idle;

    Vector3 movement;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.z);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("isFWalking", true);
            idle = "down";
        }
        else if(idle == "down")
        {
            animator.SetBool("isFWalking", false);
            animator.SetBool("isFIdle", true);
        }



    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
}
