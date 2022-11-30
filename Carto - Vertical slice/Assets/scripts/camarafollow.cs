using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camarafollow : MonoBehaviour
{
    private Vector3 startpos = new Vector3(-1, 12, -9);
    private Vector3 endpos = new Vector3(-1, 162, -141);
    private bool mapmode = false;
    private bool zoomingout;
    private bool zoomingin;
    [SerializeField] private float speed;

    private void Start()
    {
        zoomingin = false;
        zoomingout = false;
    }
    void Update()
    {

        if (Input.GetKeyDown("tab"))
        {
            Debug.Log("tab");
            if (mapmode == false)
            {
                zoomingout = true;
            }
            else if (mapmode == true)
            {
                zoomingin = true;
            }
        }

        if (zoomingin == true & gameObject.transform.position != startpos)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, startpos, speed * Time.deltaTime);
            //gameObject.transform.position += new Vector3(0, -speed, speed) * Time.deltaTime;
            if (gameObject.transform.position == startpos)
            {
                zoomingin = false;
                mapmode = false;
            }
        }

        if (zoomingout == true & gameObject.transform.position != endpos)
        {
            //gameObject.transform.position -= new Vector3(0, -speed, speed) * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endpos, speed * Time.deltaTime);
            if (gameObject.transform.position == endpos)
            {
                zoomingout = false;
                mapmode = true;
            }
        }

    }

    private void camerazoomout()
    {
        if (gameObject.transform.position != endpos & mapmode == false)
        {
            Debug.Log("camera zoom out");
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endpos, speed * Time.deltaTime);
            if(transform.position == endpos)
            {
                mapmode = true;
            }
        }
        else if (gameObject.transform.position != startpos & mapmode == true)
        {
            Debug.Log("camera zoom in");
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, startpos, speed * Time.deltaTime);
            if(transform.position == startpos)
            {
                mapmode = false;
            }
        }
    }
}
