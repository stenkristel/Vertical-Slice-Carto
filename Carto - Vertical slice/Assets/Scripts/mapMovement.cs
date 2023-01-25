using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mapMovement : MonoBehaviour
{
    public GameObject mapcharacter;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position -= new Vector3(0, 0.95f, 1.30f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0.95f, 1.30f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(1.6f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position -= new Vector3(1.6f, 0, 0);
        }
    }
}