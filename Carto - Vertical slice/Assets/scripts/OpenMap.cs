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
    private bool fading;
    [SerializeField] private float speed;
    [SerializeField] private GameObject canvas;

    [SerializeField] private GameObject cam;

    private void Start()
    {
        zoomingin = false;
        zoomingout = false;
        mapmode = false;
        speed = 1000;
    }
    void Update()
    {

        if (Input.GetKeyDown("tab") & fading == false & zoomingin == false & zoomingout == false)
        {
            fading = true;
            UIfade();
            if (mapmode == false)
            {
                zoomingout = true;
            }
            else if (mapmode == true)
            {
                zoomingin = true;
            }
        }

        camerazoomout();
    }

    private void camerazoomout()
    {
        if (zoomingin == true)
        {
            cam.transform.position += new Vector3(0, -speed, speed) * Time.deltaTime;
            if (cam.transform.position.y <= startpos.y)
            {
                zoomingin = false;
            }
        }

        if (zoomingout == true)
        {
            cam.transform.position += new Vector3(0, speed, -speed) * Time.deltaTime;
            if (cam.transform.position.y >= endpos.y)
            {
                zoomingout = false;
            }
        }
    }

    private void UIfade()
    {
        float alpha;
        if (mapmode == true)
        {
            alpha = -0.34f;
        }
        else
        {
            alpha = 0.34f;
        }
        foreach (Transform child in canvas.transform)
        {
            if (child.tag == "map")
            {
                RawImage Image = child.GetComponent<RawImage>();
                StartCoroutine(fade(Image, alpha));
            }
        }
    }

    IEnumerator fade(RawImage image, float Alpha)
    {
        image.color += new Color(0, 0, 0, Alpha);
        yield return new WaitForSeconds(0.07f);
        image.color += new Color(0, 0, 0, Alpha);
        yield return new WaitForSeconds(0.07f);
        image.color += new Color(0, 0, 0, Alpha);
        mapmode = !mapmode;
        fading = false;
    }
}
