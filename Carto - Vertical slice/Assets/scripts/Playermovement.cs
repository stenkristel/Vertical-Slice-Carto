using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    float speed = 5f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.transform.position += Vector3.back * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }
}
