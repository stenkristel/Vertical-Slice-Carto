using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;

    //Drag and drop
    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
        //image.raycastTarget = false;
        //parentAfterDrag = transform.parent;
        //transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
        //image.raycastTarget = true;
        //transform.SetParent(parentAfterDrag);
    }
}
