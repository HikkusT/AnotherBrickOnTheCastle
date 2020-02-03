using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 savePos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //savePos = transform.position;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.position = savePos;
    }
}
