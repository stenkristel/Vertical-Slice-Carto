using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placablepiece : MonoBehaviour
{
    public mapPlacement placescript;
    private SpriteRenderer image;
    public bool CANPLACE()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1);
        if (colliders.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Start()
    {
        image = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (placescript.canplace == false)
        {
            image.color = new Color(255, 0, 0);
        }
        else
        {
            image.color = new Color(255, 255, 255);
        }

        if (placescript.placed == true)
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
}
