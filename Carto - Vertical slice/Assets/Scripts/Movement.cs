using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public bool isMuted;
    public Rigidbody rb;
    public Animator animator;
    public AudioSource walking;

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

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
            isMuted = true;
            AudioPlay();
        }
        else
        {
            Unmute();
        }


    }

    private void FixedUpdate()
    {
    rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
    

    private void Unmute()
    {
        isMuted = false;
    }
    
    private void AudioPlay()
    {
        if(isMuted == true)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
