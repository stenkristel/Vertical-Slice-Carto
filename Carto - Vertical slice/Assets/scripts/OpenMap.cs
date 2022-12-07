using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMap : MonoBehaviour
{
    private Vector3 startpos = new Vector3(-1, 12, -9);
    private Vector3 endpos = new Vector3(-1, 162, -141);
    private bool mapmode = false;
    private bool zoomingout;
    private bool zoomingin;
    [SerializeField] private float speed;

    private GameObject cam;
    private GameObject canvas;

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

        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(fade());
        }

            camerazoomout();


    }

    private void camerazoomout()
    {
        if (zoomingin == true)
        {
            //camerazoomout(-speed, speed);
            cam.transform.position += new Vector3(0, -speed, speed) * Time.deltaTime;
            if (cam.transform.position.y <= startpos.y)
            {
                zoomingin = false;
                mapmode = false;
            }
        }

        if (zoomingout == true)
        {
            //camerazoomout(speed, -speed);
            cam.transform.position += new Vector3(0, speed, -speed) * Time.deltaTime;
            if (cam.transform.position.y >= endpos.y)
            {
                zoomingout = false;
                mapmode = true;
            }
        }
    }

    private void UIfade()
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.tag == "map")
            {
                RawImage Image = child.GetComponent<RawImage>();
                Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, 0.5f);
            }
        }
    }

    private IEnumerator fade(RawImage image)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, -0.1f);
        yield return new WaitForSeconds(1); 
    }
}
