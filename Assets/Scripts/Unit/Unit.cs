using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class Unit : ScriptableObject {

    public int classType; 
    public int health; 
    public int attackPower; 
    public int def; 
    public int magicAttack; 
    public int magicDefense; 
    public int dodgeDst; 
    public int moveDst; 
    public int attackRangeDst;
    public int weaponOne; 
    public int weaponTwo; 
    public int kingdom; 
}
