using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public List<Card> deck;
    public List<Card> hand;
    public Card[] currentPlay;
    public List<Card> discard;

    [SerializeField]
    private int awakeDrawCount = 5;

    private void Awake()
    {
        AwakeDraw();
        currentPlay = new Card[3];
    }

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

    private void AwakeDraw()
    {
        for (int i = 0; i < awakeDrawCount; i++)
        {
            hand.Add(deck[0]);
            deck.RemoveAt(0);
        }
        Shuffle();
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

    public void CastCard(Card _card, int position = 0)
    {
        if (currentPlay[position] != null)
        {
            hand.Add(currentPlay[position]);
        }
        currentPlay[position] = _card;
        hand.Remove(_card);
    }

    public void ResolveCard()
    {
        foreach (Card card in currentPlay)
        {
            if (card != null)
            {
                discard.Add(card);
            }
        }
        currentPlay = new Card[3];
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

    public void SetDeck(List<Card> newDeck)
    {
        deck = null;
        deck = newDeck;
    }

    public void AddCardToSlate(Card _card, int index = 0)
    {
        currentPlay[index] = _card;
        hand.Remove(_card);
    }

    public void MoveCardFromSlateToHand(Card _card)
    {
        for (int index = 0; index < currentPlay.Length; index++)
        {
            if (currentPlay[index] == _card)
            {
                currentPlay[index] = null;
                hand.Add(_card);
                break;
            }
        }
    }

}


