using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMap : MonoBehaviour
{
    private Vector3 endpos = new Vector3(-1, 162, -141);
    [SerializeField] private GameObject campos;
    [SerializeField] private int startposoffset;
    private bool mapmode = false;
    private bool zoomingout;
    private bool zoomingin;
    private bool fading;
    [SerializeField] private float speed;
    [SerializeField] private GameObject mapelements;

    [SerializeField] private GameObject cam;
    private PlayerCamera camscript;
    [SerializeField] private Movement Playermovement;
    private TilePlacement tileplacementscript;

    private void Start()
    {
        zoomingin = false;
        zoomingout = false;
        mapmode = false;
        speed = 5;
        camscript = cam.GetComponent<PlayerCamera>();
        Playermovement = gameObject.GetComponent<Movement>();
        tileplacementscript = gameObject.GetComponent<TilePlacement>();
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
                camscript.enabled = false;
                Playermovement.enabled = false;
                
            }
            else if (mapmode == true)
            {
                zoomingin = true;
                tileplacementscript.enabled = false;
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.W) & mapmode == true)
        {
            mapelements.transform.position += new Vector3(0, 10, 0);
        }
        if (Input.GetKeyDown(KeyCode.S) & mapmode == true)
        {
            mapelements.transform.position -= new Vector3(0, 10, 0);
        }
        if (Input.GetKeyDown(KeyCode.A) & mapmode == true)
        {
            mapelements.transform.position -= new Vector3(10, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) & mapmode == true)
        {
            mapelements.transform.position += new Vector3(10, 0, 0);
        }
        */

        camerazoomout();
    }

    private void camerazoomout()
    {
        if (zoomingin == true)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, campos.transform.position, speed);
            if (cam.transform.position == campos.transform.position)
            {
                zoomingin = false;
                camscript.enabled = true;
                Playermovement.enabled = true;
                
                mapmode = !mapmode;
            }
            
        }

        if (zoomingout == true)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, endpos, speed);
            if (cam.transform.position == endpos)
            {
                zoomingout = false;
                tileplacementscript.enabled = true;
                mapmode = !mapmode;
            }
        }
    }

    private void UIfade()
    {
        float alpha;
        float changepos;
        if (mapmode == true)
        {
            alpha = -0.34f;
            changepos = 2f;
        }
        else
        {
            alpha = 0.34f;
            changepos = -2f;
        }
        foreach (Transform child in mapelements.transform)
        {
            if (child.tag == "map")
            {
                SpriteRenderer Image = child.GetComponent<SpriteRenderer>();
                StartCoroutine(fade(Image, alpha, 0f));
            }
            else if (child.tag == "maptile")
            {
                SpriteRenderer Image = child.GetComponent<SpriteRenderer>();
                StartCoroutine(fade(Image, alpha, changepos));
            }
        }
    }

    IEnumerator fade(SpriteRenderer image, float Alpha, float Changepos)
    {
        image.color += new Color(0, 0, 0, Alpha);
        image.transform.position += new Vector3(0f, Changepos, -Changepos);
        yield return new WaitForSeconds(0.07f);
        image.color += new Color(0, 0, 0, Alpha);
        image.transform.position += new Vector3(0f, Changepos, -Changepos);
        yield return new WaitForSeconds(0.07f);
        image.color += new Color(0, 0, 0, Alpha);
        image.transform.position += new Vector3(0f, Changepos, -Changepos);
        fading = false;
    }
}
