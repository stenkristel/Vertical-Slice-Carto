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
    [SerializeField] private GameObject maptiles;

    [SerializeField] private GameObject cam;
    private PlayerCamera camscript;
    [SerializeField] private Movement Playermovement;
    private TilePlacement tileplacementscript;
    public Placablepiece Placablepiecescript;
    public mapPlacement MapPlacementscript;
    public mapMovement mapMovementscript;

    [SerializeField] private GameObject Mapcharacter;
    [SerializeField] private GameObject scope;
    [SerializeField] private GameObject toolbar;
    public GameObject Player;

    //public GameObject Piece;
    private void Start()
    {
        zoomingin = false;
        zoomingout = false;
        mapmode = false;
        speed = 5;
        camscript = cam.GetComponent<PlayerCamera>();
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
                asignMapChaPos();
                zoomingout = true;
                camscript.enabled = false;
                Playermovement.enabled = false;

            }
            else if (mapmode == true)
            {
                zoomingin = true;
                tileplacementscript.enabled = false;
                Placablepiecescript.enabled = false;
                mapMovementscript.enabled = false;
                MapPlacementscript.enabled = false;
            }
        }
        camerazoomout();
        //Mapcharacter.gameObject.transform.position = findmatchingMAPpiece(Piece).gameObject.transform.position;
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
                Placablepiecescript.enabled = true;
                mapMovementscript.enabled = true;
                MapPlacementscript.enabled = true;
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
        }
        foreach (Transform Child in maptiles.transform)
        {
            SpriteRenderer Image = Child.GetComponent<SpriteRenderer>();
            StartCoroutine(fade(Image, alpha, changepos));
        }

        foreach (Transform CHILD in scope.transform)
        {
            foreach (Transform CHIld in CHILD)
            {
                SpriteRenderer Image = CHIld.GetComponent<SpriteRenderer>();
                StartCoroutine(fade(Image, alpha, 0f));
            }
        }

        foreach (Transform chold in toolbar.transform)
        {
            if (chold.tag == "map")
            {
                SpriteRenderer Image = chold.GetComponent<SpriteRenderer>();
                StartCoroutine(fade(Image, alpha, 0f));
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

    public void asignMapChaPos()
    {
        GameObject Piece = findcurrentOWmap();
        Debug.Log(Piece);
        Mapcharacter.gameObject.transform.position = findmatchingMAPpiece(Piece).gameObject.transform.position;
        Mapcharacter.gameObject.transform.position -= new Vector3(0, 0, 0.1f);
        //Mapcharacter.transform.SetParent(findmatchingMAPpiece(Piece).transform, false);
    }

    public void MoveMaptoMiddle(GameObject MapPiece)
    {
        float xdistance = MapPiece.transform.position.x;
        Debug.Log(xdistance);
        foreach (Transform child in maptiles.transform)
        {
            child.transform.position -= new Vector3(xdistance, 0, 0);
        }
    }

    public GameObject findcurrentOWmap()
    {
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out RaycastHit hit, 5f))
        {
            return hit.collider.gameObject;
        }
        else return null;
    }
    public GameObject findmatchingMAPpiece(GameObject OWpiece)
    {
        if (OWpiece != null)
        {
            return GameObject.Find(OWpiece.name.Remove(2));
        }
        else return null;
    }
}