using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacement : MonoBehaviour
{
    public GameObject selectedpiece;
    public GameObject nearbytile;
    private float xdir;
    private float zdir;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            nearbytile = findUItile();
            if (nearbytile != null)
            {
                placeoverworldtile();
            }
            Debug.Log("Find UI tiles = " + nearbytile);
        }
    }

    public void placeoverworldtile()
    {
        GameObject selectedpieceOW = findmathcingOWpiece(selectedpiece);
        GameObject nearbypieceOW = findmathcingOWpiece(nearbytile);
        selectedpieceOW.gameObject.transform.position = new Vector3(nearbypieceOW.transform.position.x + xdir, nearbypieceOW.transform.position.y, nearbypieceOW.transform.position.z + zdir);
    }

    public GameObject findUItile()
    {
        Vector3 dis = Vector3.down;
        for (int i = 0; i < 4f; i++)
        {
            switch (i)
            {
                case 0:
                    dis = Vector3.down;
                    zdir = 40;
                    xdir = 0;
                    break;
                case 1:
                    dis = Vector3.up;
                    zdir = -40;
                    xdir = 0;
                    break;
                case 2:
                    dis = Vector3.right;
                    zdir = 0;
                    xdir = -40;
                    break;
                case 3:
                    dis = Vector3.left;
                    zdir = 0;
                    xdir = 40;
                    break;
            }
            GameObject UItile =  raycastUItile(dis);
            if (UItile != null)
            {
                return UItile;
            }
        }
        return null;
    }

    public GameObject raycastUItile(Vector3 distance)
    {
        if (Physics.Raycast(selectedpiece.transform.position, selectedpiece.transform.TransformDirection(distance), out RaycastHit hit, 5f))
        { 
            return hit.collider.gameObject;
        }
        else return null;
    }
    public GameObject findmathcingOWpiece(GameObject piece)
    {
        if (piece != null)
        {
            return GameObject.Find(piece.name + "OW");
        }
        else return null;
    }
}
