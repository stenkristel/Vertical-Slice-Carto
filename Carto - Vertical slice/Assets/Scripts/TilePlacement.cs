using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject selectedpiece;


    //je drukt op de map piece in de (fake)UI
    //er wordt aan deze functie doorgegeven welke UI piece je geslect hebt
    public void takemappiece(GameObject piece)
    {
        GameObject.Find(piece + "OW");
        //De zoekt nu de mappiece in de OW met dezelfde naam van de UIpiece die je geselect hebt + OW
    }

}
