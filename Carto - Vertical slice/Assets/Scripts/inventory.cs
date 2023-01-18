using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public GameObject InventoryUI;
    public GameObject MapPiece; //Placeholder is een button voor nu.

    // Start is called before the first frame update
    void Start()    
    {
        GetComponent<inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(InventoryUI.isStatic)
        {
            InventoryUI.SetActive(true);

            //if(inventoryUI.isActive)
            {
                Input.GetKeyDown(KeyCode.E);
                Debug.Log("E is pressed");
            }
    
        }

    }
}
