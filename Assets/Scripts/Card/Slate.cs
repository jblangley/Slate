using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Slate", menuName = "Slate")]
public class Slate : ScriptableObject {

    public Card result;

    [SerializeField]
    Card[] recipe = new Card[3];

    public Card[] GetRecipe()
    {
        Array.Sort(recipe, (x,y) => string.Compare(x.cardName,y.cardName));
        return recipe;
    }
}
