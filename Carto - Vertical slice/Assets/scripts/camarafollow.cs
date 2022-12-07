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
        mapmode = false;
        speed = 1000;
    }
    void Update()
    {

        if (Input.GetKeyDown("tab"))
        {
            if (mapmode == false)
            {
                zoomingout = true;
                //camerazoomout(speed, speed);
            }
            else if (mapmode == true)
            {
                zoomingin = true;
                //camerazoomout(speed, speed);
            }
        }

        
        

        if (zoomingin == true)
        {
            //camerazoomout(-speed, speed);
            gameObject.transform.position += new Vector3(0, -speed, speed) * Time.deltaTime;
            if (gameObject.transform.position.y <= startpos.y)
            {
                zoomingin = false;
                mapmode = false;
            }
        }

        if (zoomingout == true)
        {
            //camerazoomout(speed, -speed);
            gameObject.transform.position += new Vector3(0, speed, -speed) * Time.deltaTime;
            if (gameObject.transform.position.y >= endpos.y)
            {
                zoomingout = false;
                mapmode = true;
            }
        }
    }


    //private void camerazoomout(float yspeed, float zspeed)
    //{
        //gameObject.transform.position += new Vector3(0, yspeed, zspeed) * Time.deltaTime;
        //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endpos, speed);
        //if (gameObject.transform.position.y <= startpos.y)
        //{
            //zoomingin = false;
            //mapmode = false;
        //}
        //else if (gameObject.transform.position.y >= endpos.y)
        //{
            //zoomingout = false;
            //mapmode = true;
        //}
        //else
        //{
            //camerazoomout(yspeed, zspeed);
        //}
    //}
}