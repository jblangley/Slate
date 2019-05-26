using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public List<Card> deck;
    public List<Card> hand;
    public List<Card> discard;

    public void AddCard(Card card)
    {
        deck.Add(card);
    }

    public void AddCards(List<Card> cardsAdding)
    {
        deck.AddRange(cardsAdding);
    }

    void Shuffle()
    {
        int count = deck.Count;
        for (int index = 0; index < count; index++)
        {
            int rand = Random.Range(index, deck.Count);
            Card temp = deck[rand];
            deck[rand] = deck[index];
            deck[index] = temp;
        }
    }

    public Card DrawCard()
    {
        hand.Add(deck[0]);
        deck.RemoveAt(0);
        if (deck.Count == 0)
        {
            RefillDeck();
        }
        Shuffle();
        return hand[hand.Count - 1];
    }

    public void HandToDisacrd(int num)
    {
        discard.Add(hand[num]);
        hand.RemoveAt(num);
    }

    public void RefillDeck()
    {
        deck.AddRange(discard);
        discard = null;
    }
}


