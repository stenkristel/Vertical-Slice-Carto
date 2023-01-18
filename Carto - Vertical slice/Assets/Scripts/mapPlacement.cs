using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapPlacement : MonoBehaviour
{
    public GameObject CenterPos;
    public GameObject A1; //is de naam van de Map Pieces

    void Start()
    {
        //mapPiece.transform.position = new Vector3(0, 0, 0);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PieceMovement();
        }
    }

    private void PieceMovement()
    {
        A1.transform.position = CenterPos.transform.position;
    }
}
