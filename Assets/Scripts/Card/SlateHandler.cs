using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class SlateHandler : MonoBehaviour
{
    [SerializeField]
    Slate[] allSlatesCache;

    public static SlateHandler instance;

    private void Awake()
    {
        instance = this;
        //IntailizeSlates();
    }

    private void Start()
    {
        allSlatesCache = Resources.LoadAll<Slate>("Slates");
    }

    public Card CheckIfItsASlate(Card[] check)
    {
        if (check[0] != null && check[1] != null && check[2] != null)
        {
            Array.Sort(check, (x, y) => string.Compare(x.cardName, y.cardName));
            for (int indexlist = 0; indexlist < allSlatesCache.Length; indexlist++)
            {
                Card[] temp = allSlatesCache[indexlist].GetRecipe();
                Debug.Log("checking slate");
                if (temp[0] == check[0] && check[1] == temp[1] && check[2] == temp[2])
                {
                    Debug.Log("Slated for victory!");
                    return allSlatesCache[indexlist].result;
                }
            }
        }
        return null;
    }
}
