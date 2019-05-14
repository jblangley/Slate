using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideNextAction : MonoBehaviour {

    //public LayerMask unitsLayer;
    PlayerController controller;
    Combat comb;

	void Start () {
        controller = GetComponent<PlayerController>();
        comb = GetComponent<Combat>();
    }

    public void NextAction()
    {
        controller.CheckIsUnit();
        if (controller.isUnit)
        {
            TargetUnit();
        }
        else
        {
            TargetWorldPosition();
        }
    }

    private void TargetWorldPosition()
    {
        if (Vector3.Distance(controller.ultimateTarget, controller.transform.position) < controller.inRangeDst)
        {//Debug.Log("Reached Target");
            controller.agent.ResetPath();
        }
        else
        {//Debug.Log("Moving to Target");
            controller.CalculatePath();
            controller.MoveUnit();
        }
    }

    private void TargetUnit()
    {
        if (Vector3.Distance(controller.targetUnit.transform.position, transform.position) < controller.inRangeDst)
        {//KOMBAT
            comb.Attack(controller.targetUnit, gameObject);
            //Debug.Log("Hitem");
        }
        else
        {//Debug.Log("Chasing Unit");
            controller.CalculatePath();
            controller.MoveUnit();
        }
    }
}
