using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGridHandler : MonoBehaviour {

    GameObject getCardHandler;
    CardHandler cardHandler;
    GameObject getCurrentCardHandler;
    CardHandler currentCardHandler;
    SlateHandler slateHandler;
    Deck deck;



    void Start () {
        getCardHandler = GameObject.FindGameObjectWithTag("Hand");
        cardHandler = getCardHandler.GetComponent<CardHandler>();
        getCurrentCardHandler = GameObject.FindGameObjectWithTag("CurrentCard");
        currentCardHandler = getCurrentCardHandler.GetComponent<CardHandler>();
        slateHandler = FindObjectOfType<SlateHandler>();

    }


    public void ChangeSelectedUnit(Deck _deck)
    {
        deck = _deck;
        cardHandler.ResetDeck(_deck);
        currentCardHandler.ResetPlay(_deck);
    }

    public void PlayCard(CardDisplay card)
    {
        Draggable[] draggableCCH = GetChildern();
        MoveCardToHandFromCurrentPlay(draggableCCH);

        Draggable draggableCastingCard = card.GetComponent<Draggable>();
        draggableCastingCard.parentToReturnTo = currentCardHandler.transform;

        deck.CastCard(card.card);
    }

    public void MoveCardFromSlateToHand(GameObject card)
    {
        CardDisplay cardDisplay = card.GetComponent<CardDisplay>();
        deck.MoveCardFromSlateToHand(cardDisplay.card);
    }

    public bool PlayCardToSlateDropzone(GameObject card)
    {
        CardDisplay cardDisplay = card.GetComponent<CardDisplay>();
        Draggable[] temp = GetChildern();
        if (temp.Length < 3)
        {
            deck.AddCardToSlate(cardDisplay.card, temp.Length);
            if (deck.currentPlay.Length == 3)
            {
                Card slated = slateHandler.CheckIfItsASlate(deck.currentPlay);
                if (slated != null)
                {
                    currentCardHandler.CreateSlate(slated);
                    Destroy(cardDisplay.gameObject);
                    Debug.Log("is a slate!!");
                }
            }
            return true;
        }
        return false;
    }

    void MoveCardToHandFromCurrentPlay(Draggable[] currentPlay, int index = 0)
    {
        if (currentPlay.Length >= index + 1)
        {
            currentPlay[index].parentToReturnTo = cardHandler.transform;
            currentPlay[index].transform.SetParent(cardHandler.transform);
        }
    }

    Draggable[] GetChildern()
    {
        int childCount = currentCardHandler.gameObject.transform.childCount;
        Draggable[] listOfChildern = new Draggable[childCount];
        for (int index = 0; index < childCount; index++)
        {
            Transform temp = currentCardHandler.transform.GetChild(index);
            listOfChildern[index] = temp.GetComponent<Draggable>();
        }
        return listOfChildern;
    }
}
