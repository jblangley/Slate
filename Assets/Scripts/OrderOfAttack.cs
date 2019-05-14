using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderOfAttack : MonoBehaviour
{

    int maxWeight = 5;

    void Start()
    {

    }

    public void AttackOrder(List<UnitBaseStats> unitStatus)
    {

        //Guard
        //Dodge
        //Attack/Slate Attack
        //Move
        //If move is now in range Attack(no slate)

    }

    public void TurnCounter(UnitBaseStats unitStatus, int weight)
    {
        unitStatus.turnWeight += weight;
        if (unitStatus.turnWeight > maxWeight)
        {
            unitStatus.turnWeight = maxWeight;
        }
        unitStatus.turnWeight -= 1;
        if (unitStatus.turnWeight < 0)
        {
            unitStatus.turnWeight = 0;
        }
    }
}
