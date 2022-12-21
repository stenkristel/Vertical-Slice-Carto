using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject selectedpiece;
    
    
    public GameObject takemappiece(GameObject piece)
    {
        return GameObject.Find(piece.name + "OW");
    }

}
