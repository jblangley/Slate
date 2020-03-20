using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    Card cardToAttackWith;
    Deck deckHandler;

    [SerializeField]
    CombatState state = 0;


    void Awake()
    {
        deckHandler = GetComponent<Deck>();
    }

    public void SetCard(Card card)
    {
        cardToAttackWith = card;
        state = cardToAttackWith.GetState();
    }

    public Card GetCard()
    {
        return cardToAttackWith;
    }

    public bool Interaction(GameObject target)
    {
        bool check = false;
        UnitBaseStats targetStats = target.GetComponent<UnitBaseStats>();
        if (targetStats)
        {
            check = CombatSwitch(target, targetStats);
            isTargetDead(targetStats);
        }
        return check;
    }

    private void isTargetDead(UnitBaseStats targetStats)
    {
        if (targetStats.health < 1)
        {
            GetComponent<PlayerController>().OnDeath();
            Destroy(targetStats.gameObject);
        }
    }

    private bool CombatSwitch(GameObject target, UnitBaseStats targetStats)
    {
        switch (state)
        {
            case CombatState.Idle:
                Debug.Log("Idle");
                deckHandler.ResolveCard();
                return true;

            case CombatState.Guarding:
                Debug.Log("Guard");
                deckHandler.ResolveCard();
                return true;

            case CombatState.Dodging:
                Debug.Log("Dodge");
                deckHandler.ResolveCard();
                return true;

            case CombatState.Attacking:
                if (cardToAttackWith.range > Vector3.Distance(target.transform.position, transform.position))
                {
                    targetStats.health -= cardToAttackWith.damage;
                    Debug.Log("Attack");
                    deckHandler.ResolveCard();
                    return true;
                }
                break;

            case CombatState.RangeAttacking:
                if (cardToAttackWith.range > Vector3.Distance(target.transform.position, transform.position))
                {
                    targetStats.health -= cardToAttackWith.damage;
                    deckHandler.ResolveCard();
                    return true;
                }
                Debug.Log("Range");
                break;

            case CombatState.SlateAttacking:
                deckHandler.ResolveCard();
                Debug.Log("Slate");
                return true;

            case CombatState.Healing:
                targetStats.health += cardToAttackWith.damage;
                deckHandler.ResolveCard();
                return true;

            default:
                Debug.Log("Default");
                return true;
        }

        return false;
    }



    //public void RangeAttack()
    //{

    //}

    public void SlateAttack()
    {

    }

    public bool OnSameTeam(UnitBaseStats one, UnitBaseStats two)
    {
        if (one.kingdom.GetId() == two.kingdom.GetId())
        {
            return true;
        }
        return false;
    }

    //private void CheckIfUnitIsEngaged()
    //{
    //    Collider[] targetsInViewRadius = Physics.OverlapSphere(cont.transform.position, cont.maxMoveDst, unitsLayer);
    //    for (int i = 0; i < targetsInViewRadius.Length; i++)
    //    {
    //        int counter = 0;
    //        for (int innerindex = i + 1; innerindex < targetsInViewRadius.Length - 1; innerindex++)
    //        {
    //            UnitBaseStats unitTwo = targetsInViewRadius[innerindex].GetComponent<UnitBaseStats>();
    //            if (stats.kingdom != unitTwo.kingdom)
    //            {
    //                //unitOne.isEngaged = true;
    //                //unitTwo.isEngaged = true;
    //                counter++;
    //            }
    //        }
    //        if (counter == 0)
    //        {
    //            //unitOne.isEngaged = false;
    //        }
    //    }
    //}
}