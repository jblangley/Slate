using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour {

    public GameObject CardUI;
    public CardDisplay display;
    public Deck deck;

    void Start()
    {
        deck = GetComponent<Deck>();
    }

    public void CreateCard()
    {
        display.ChangeCard(deck.DrawCard());
        Instantiate(display, transform);
    }

    public void CreateCard(Card card)
    {
        display.ChangeCard(card);
        Instantiate(display, transform);
    }

    public void CreateSlate(Card slate)
    {
        deck.ResolveCard();
        deck.currentPlay[0] = slate;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        display.ChangeCard(slate);
        Instantiate(display, transform);
    }

    public void DeleteCard()
    {
        deck.HandToDisacrd(0);
        Destroy(display);
    }

    public void ResetDeck(Deck reset)
    {
        DeleteHand();
        deck = reset;
        for (int index = 0; index < deck.hand.Count; index++)
        {
            CreateCard(deck.hand[index]);
        }
    }

    public void ResetPlay(Deck reset)
    {
        DeleteHand();
        deck = reset;
        for (int index = 0; index < deck.currentPlay.Length; index++)
        {
            if (deck.currentPlay[index] != null)
            {
                CreateCard(deck.currentPlay[index]);
            }
        }
    }

    void DeleteHand()
    {
        Transform[] toDelete = GetComponentsInChildren<Transform>();
        for (int index = 1; index < toDelete.Length; index++)
        {
            Destroy(toDelete[index].gameObject);
        }
    }
}
