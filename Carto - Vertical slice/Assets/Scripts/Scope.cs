using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapPlace : MonoBehaviour
{

    public GameObject Scope1;
    public GameObject Scope2;
    public bool scope1 = true;

    // Start is called before the first frame update
    void Start()
    {

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


        