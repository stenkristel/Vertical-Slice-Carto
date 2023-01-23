using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapPlacement : MonoBehaviour
{
    public GameObject CenterPos;
    public GameObject A1; //is de naam van de Map Pieces
    public GameObject A1OW; //De naam van de Overworld Piece

    public GameObject BG; //Staat voor de background, waar je de map piece op moet plaatsen. 
    public GameObject Scope; 

    void Start()
    {
        GetComponent<TilePlacement>();
        //Debug.Log(transform.parent);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PieceMovement();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            PieceRotationA();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            PieceRotationD();
        }

        //A1.transform.SetParent(BG.transform, false);
        
    }

    private void PieceMovement()
    {
        A1.transform.position = CenterPos.transform.position;

        if (Input.GetKeyDown(KeyCode.W))
            {
                transform.localScale = new Vector3(2, 2, 0);
            }

        if (A1.transform.position == Scope.transform.position)
        {
            A1.transform.SetParent(BG.transform, false);
        }

    }

    public void PieceRotationA()
    {
        A1.transform.localEulerAngles += new Vector3(0, 0, 90);
    }

    public void PieceRotationD()
    {
        A1.transform.localEulerAngles -= new Vector3(0, 0, 90);
    }


    private void PlaceMapPiece()
    {
        //A1.transform.SetParent(Inventory, false);
        //A1.transform.SetParent(Background, true);
    }
}
