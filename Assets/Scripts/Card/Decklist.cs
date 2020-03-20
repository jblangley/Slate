using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Decklist", menuName = "Deck")]
public class Decklist : ScriptableObject {

    public List<Card> Deck;

}
