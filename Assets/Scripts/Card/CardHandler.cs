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

    public void DeleteCard()
    {
        deck.HandToDisacrd(0);
        Destroy(display);
    }
}
