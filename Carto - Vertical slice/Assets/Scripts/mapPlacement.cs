using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapPlacement : MonoBehaviour
{
    public GameObject CenterPos;
    public GameObject Mapelements;
    public GameObject maptiles;
    public GameObject Scope1;
    public GameObject Scope2;
    public GameObject A1; //is de naam van de Map Pieces
    public bool placed = false;
    public Placablepiece A1script;
    public TilePlacement tileplacementscript;
    private bool PLacemntmode;
    public bool canplace;
    void Update()
    {
        canplace = A1script.CANPLACE();

        if (PLacemntmode)
        {
            Scope1.SetActive(false);
            Scope2.SetActive(true);
        }
        else
        {
            Scope1.SetActive(true);
            Scope2.SetActive(false);
        }

        if (PLacemntmode == false & Input.GetKeyDown(KeyCode.W) & placed == false)
        {
            PieceMovement();
            PLacemntmode = true;

        }
        else if  (PLacemntmode == true & Input.GetKeyDown(KeyCode.W) & canplace == true)
        {
            tileplacementscript.starttileplacement();
            PLacemntmode = false;
            placed = true;
        }
    }

    private void PieceMovement()
    {
        A1.transform.SetParent(Mapelements.transform, false);
        A1.transform.position = CenterPos.transform.position;
        A1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2858777f);
    }


}
