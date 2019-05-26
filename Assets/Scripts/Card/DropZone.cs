using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {


    public void OnDrop(PointerEventData eventData)
    {
        //Draggable dragObj = eventData.pointerDrag.GetComponent<Draggable>();
        //dragObj.parentToReturnTo = this.transform;
        CheckSpacing();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //throw new NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //throw new NotImplementedException();
    }

    public void DropHere()
    {
        
    }

    void CheckSpacing()
    {
        //Check spacing between cards
        HorizontalLayoutGroup layout = GetComponent<HorizontalLayoutGroup>();
        Draggable[] childern = GetComponentsInChildren<Draggable>();
        layout.spacing = 0;
        for (int i = 0; i < childern.Length; i++)
        {
            layout.spacing -= 8;
        }
    }
}
