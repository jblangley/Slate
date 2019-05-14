using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]// in menuname, can create a sub menu for differnt card types with /
public class Card : ScriptableObject {

    public bool isArea;
    public bool isMagic;
    public bool isMelee;

    public string cardName;
    public string description;

    public Sprite fgArtwork;
    public Sprite bgArtwork;

    public int range;
    public int damage;

    //Methods can be added
}
