using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacement : MonoBehaviour
{
    public GameObject selectedpiece;
    public GameObject nearbytile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            nearbytile = findUItiles();
            placeoverworldtile();
            Debug.Log("Find UI tiles = " + nearbytile);
        }
    }

    public void placeoverworldtile()
    {
        GameObject selectedpieceOW = takemappiece(selectedpiece);
        GameObject nearbypieceOW = takemappiece(nearbytile);
        selectedpieceOW.gameObject.transform.position = new Vector3(nearbypieceOW.transform.position.x, nearbypieceOW.transform.position.y, nearbypieceOW.transform.position.z + 40);
    }

    public GameObject findUItiles()
    {
        Vector3 dis = Vector3.down;
        for (int i = 0; i < 4f; i++)
        {
            switch (i)
            {
                case 0:
                    dis = Vector3.down;
                    break;
                case 1:
                    dis = Vector3.up;
                    break;
                case 2:
                    dis = Vector3.right;
                    break;
                case 3:
                    dis = Vector3.left;
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
        Debug.Log("shooting raycast" + distance);
        if (Physics.Raycast(selectedpiece.transform.position, selectedpiece.transform.TransformDirection(distance), out RaycastHit hit, 5f))
        { 
            return hit.collider.gameObject;
        }
        else return null;
    }
    public GameObject takemappiece(GameObject piece)
    {
        return GameObject.Find(piece.name + "OW");
    }

}
