using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    Animator PlayerAnimator;

    private void Start()
    {
        PlayerAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            PlayerAnimator.SetBool("up", true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
            PlayerAnimator.SetBool("down", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            PlayerAnimator.SetBool("left", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            PlayerAnimator.SetBool("right", true);
        }
        else
        {
            PlayerAnimator.SetBool("idle", true);
        }
    }
}
