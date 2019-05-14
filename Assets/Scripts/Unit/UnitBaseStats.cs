using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBaseStats : MonoBehaviour
{

    public int classType { get; set; }
    public int health { get; set; }
    public int attackPower { get; set; }
    public int def { get; set; }
    public int magicAttack { get; set; }
    public int magicDefense { get; set; }
    public int elementResistance { get; set; }
    public int dodgeDst { get; set; }
    public int moveDst { get; set; }
    public int attackRangeDst { get; set; }
    public int weaponOne { get; set; }
    public int weaponTwo { get; set; }
    public int kingdom { get; set; }
    public int moveStatus { get; set; }
    public int turnWeight { get; set; }
    public enum CombatState { get }
    public ICombatState.CombatState  combatState {get; set;}
 

    public UnitBaseStats()
    {
        classType = 0;
        health = 10;
        attackPower = 5;
        def = 0;
        magicAttack = 2;
        magicDefense = 3;
        elementResistance = 0;
        dodgeDst = 4;
        moveDst = 7;
        attackRangeDst = 3;
        combatState = 0;
    }
}
