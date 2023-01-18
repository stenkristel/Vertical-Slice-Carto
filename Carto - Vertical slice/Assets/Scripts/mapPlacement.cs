using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapPlacement : MonoBehaviour
{
    public GameObject CenterPos;
    public GameObject A1; //is de naam van de Map Pieces
    //public GameObject A2;

    private Transform Inventory;

    void Start()
    {
        GetComponent<Scope>();
        GetComponent<inventory>();
        Debug.Log(transform.parent);
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

        A1.transform.SetParent(Inventory, true);
    }

    private void PieceMovement()
    {
        A1.transform.position = CenterPos.transform.position;
        if (Input.GetKeyDown(KeyCode.W))
            {
                transform.localScale = new Vector3(2, 2, 0);
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

    //transform.parent = newObject.transform;
    //transform.parent = newParent; // where newParent is also a transform

}
