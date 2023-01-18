using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scope : MonoBehaviour
{

    public GameObject Scope1;
    public GameObject Scope2;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<mapPlacement>();
        Scope1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Scope1.SetActive(!Scope1.active);
            Scope2.SetActive(!Scope2.active);
        }

      
       
    }

   
}


        