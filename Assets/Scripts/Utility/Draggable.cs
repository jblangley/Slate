using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    List<RaycastResult> rays = new List<RaycastResult>();
    public Vector2 offset = new Vector2(0, 0);

	public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = transform.parent;
        transform.SetParent(transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //These are for casting cards
        EventSystem.current.RaycastAll(eventData, rays);
        CheckWhatWasHit();

        //These are needed as the base
        transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void CheckWhatWasHit()
    {
        for (int index = 0; index < rays.Count; index++)
        {
            RaycastResult temp = rays[index];

            if (temp.gameObject.GetComponent<DropZone>())
            {
                bool check = true;
                if (temp.gameObject.tag == "Hand")
                {
                    GameObject setup = GameObject.FindGameObjectWithTag("CardGrid");
                    CardGridHandler CGH = setup.GetComponent<CardGridHandler>();
                    CGH.MoveCardFromSlateToHand(gameObject);
                }
                else if (temp.gameObject.tag == "CurrentCard")
                {
                    GameObject setup = GameObject.FindGameObjectWithTag("CardGrid");
                    CardGridHandler CGH = setup.GetComponent<CardGridHandler>();
                    check = CGH.PlayCardToSlateDropzone(gameObject);
                }
                if (check)
                {
                    parentToReturnTo = temp.gameObject.transform;
                }
            }
            else if (temp.gameObject.CompareTag("Unit"))
            {
                //Do Stuff
                GameManager manager = FindObjectOfType<GameManager>();
               manager.TargetUnit(temp.gameObject, gameObject.GetComponent<CardDisplay>());
                
                //Highlight the card in someway
            }
        }
    }
}
