using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mapMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 10, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= new Vector3(0, 10, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position -= new Vector3(10, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(10, 0, 0);
        }
    }
}