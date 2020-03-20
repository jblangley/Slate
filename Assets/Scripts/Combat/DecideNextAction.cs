using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideNextAction
{
    //public static void NextAction(PlayerController _controller)
    //{
    //    //Moving a unit to target posistion
    //    _controller.CheckIsUnit();
    //    if (_controller.isUnit)
    //    {
    //        TargetUnit(_controller);
    //    }
    //    else
    //    {
    //        TargetWorldPosition(_controller);
    //    }
    //}

    //private static void TargetWorldPosition(PlayerController _controller)
    //{
    //    if (Vector3.Distance(_controller.ultimateTarget, _controller.transform.position) < _controller.inRangeToEngage)
    //    {//Debug.Log("Reached Target");
    //        _controller.agent.ResetPath();
    //    }
    //    else
    //    {//Debug.Log("Moving to Target");
    //        _controller.CalculatePath();
    //        _controller.MoveUnit();
    //    }
    //}

    //private static void TargetUnit(PlayerController _controller)
    //{
    //    Combat _combat = _controller.GetComponent<Combat>();
    //    bool didIAttack = false;

    //    if (_combat.GetCard() != null)
    //    {
    //        didIAttack = _combat.Interaction(_controller.targetUnit);
    //    }

    //    if (didIAttack == false && Vector3.Distance(_controller.targetUnit.transform.position, _controller.transform.position) > _controller.inRangeToEngage)
    //    {
    //        //Debug.Log("Chasing Unit");
    //        _controller.CalculatePath();
    //        _controller.MoveUnit();
    //    }
    //}
}
