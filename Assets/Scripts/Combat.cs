using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour{

    public LayerMask unitsLayer;


    void SetCombatChoice(int choice, UnitBaseStats unit)
    {
        
    }
	
    public void Attack(GameObject target, GameObject attacker)
    {
        UnitBaseStats targetStats = target.GetComponent<UnitBaseStats>();
        UnitBaseStats attackerStats = attacker.GetComponent<UnitBaseStats>();
        SetCombatChoice(1,targetStats);
        SetCombatChoice(1, attackerStats);
        if (targetStats)
        {
            targetStats.health -= attackerStats.attackPower + targetStats.def;
        }
        else
        {
            targetStats.health -= attackerStats.attackPower;
        }
    }

    public void Guard(GameObject unit)
    {
        PlayerController unitStats = unit.GetComponent<PlayerController>();
        unitStats.isGuarding = true;
    }

    public void Dodge(GameObject unit)
    {
        PlayerController unitStats = unit.GetComponent<PlayerController>();
        unitStats.isDodging = true;
    }

    //public void RangeAttack()
    //{

    //}

    public void SlateAttack()
    {

    }

    private void CheckIfUnitIsEngaged()
    {
        PlayerController controller = GetComponent<PlayerController>();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(controller.transform.position, controller.maxMoveDst, unitsLayer);
        UnitBaseStats unitOne = controller.GetComponent<UnitBaseStats>();
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            int counter = 0;
            for (int innerindex = i + 1; innerindex < targetsInViewRadius.Length - 1; innerindex++)
            {
                UnitBaseStats unitTwo = targetsInViewRadius[innerindex].GetComponent<UnitBaseStats>();
                if (unitOne.kingdom != unitTwo.kingdom)
                {
                    //unitOne.isEngaged = true;
                    //unitTwo.isEngaged = true;
                    counter++;
                }
            }
            if (counter == 0)
            {
                //unitOne.isEngaged = false;
            }
        }
    }
}

public class ICombatState
{
    public enum CombatState { Idle = 0, Engaged, Guarding, Dodging, Attacking, SlateAttacking};
    
}
