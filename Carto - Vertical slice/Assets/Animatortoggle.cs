using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatortoggle : MonoBehaviour
{
    //front.gameObject.SetActive(true);
    //back.gameObject.SetActive(false);

    //public Rigidbody rb;
    //public GameObject front;
    //public GameObject back;
    void CheckIfMovingUpOrDown()
    {

        float currentZ = transform.position.z;
        float lastZ = currentZ;



        if (currentZ > lastZ)
        {
            Debug.Log("going down");
        }
        else
        {
            Debug.Log("going up");
        }
    }
}
