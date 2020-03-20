using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 

public class UnitBaseStats : MonoBehaviour
{
    public Unit unitSet;
    public int classType;
    [SerializeField]
    public int health;
    public int moveDst;
    public int kingdomID;
    public Kingdom kingdom;

    private void Awake()
    {
        classType = unitSet.classType;
        health = unitSet.health;
        moveDst = unitSet.moveDst;
    }

    //public int attackPower { get; set; }
    //public int def { get; set; }
    //public int magicAttack { get; set; }
    //public int magicDefense { get; set; }
    //public int elementResistance { get; set; }
    //public int dodgeDst { get; set; }
    //public int attackRangeDst { get; set; }
    //public int weaponOne { get; set; }
    //public int weaponTwo { get; set; }
    //public int moveStatus { get; set; }
    //public int turnWeight { get; set; }

    //public UnitBaseStats()
    //{
    //    classType = 0;
    //    health = 10;
    //    moveDst = 7;

    //    //attackPower = 5;
    //    //def = 0;
    //    //magicAttack = 2;
    //    //magicDefense = 3;
    //    //elementResistance = 0;
    //    //dodgeDst = 4;
    //    //attackRangeDst = 3;
    //}


}
