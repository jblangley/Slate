using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    NavMeshPath path;
    public Vector3 ultimateTarget;
    public GameObject targetUnit;
    public bool isUnit = false;
    public float maxMoveDst = 5f;
    public float inRangeToEngage = 2f;
    public int moveStatus = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ultimateTarget = transform.position;
        maxMoveDst = GetComponent<UnitBaseStats>().moveDst;
        FindObjectOfType<GameManager>().EvTakeTurn += NextAction;
    }

    public void OnDeath()
    {
        FindObjectOfType<GameManager>().EvTakeTurn -= NextAction;
    }

    public void SetTargetPath(GameObject _target)
    {
        targetUnit = _target;
        isUnit = true;
    }

    public void SetTargetPath(Vector3 _target)
    {//Debug.Log("Set position in world");
        ultimateTarget = _target;
        isUnit = false;
    }

    public void MoveUnit()
    {
        Vector3 target = CheckDistance();
        agent.SetDestination(target);
    }

    public bool CheckIsUnit()
    {
        if (targetUnit == null && ultimateTarget == new Vector3(0, 0, 0))
        {
            isUnit = false;
            ultimateTarget = transform.position;
        }
        else if (targetUnit != null)
        {
            isUnit = true;
        }
        return isUnit;
    }

    public void CalculatePath()
    {
        if (isUnit)
        {
            NavMeshPath _path = new NavMeshPath();
            agent.CalculatePath(targetUnit.transform.position, _path);
            path = _path;
        }
        else
        {
            NavMeshPath _path = new NavMeshPath();
            agent.CalculatePath(ultimateTarget, _path);
            path = _path;
        }
        agent.ResetPath();//This resets the current path attached to the agent component, NOT the path being used in the script. So if we change targets it will reset the agent and create the new path
    }

    Vector3 CheckDistance()
    {//Debug.Log("Started CheckDistance " + name);
        Vector3 anchor = this.transform.position;//The anchor starts as the current transform but gets saved as previous coner to go back to

        for (int index = 0; index < path.corners.Length; index++)
        {
            if (Vector3.Distance(transform.position,path.corners[index]) > maxMoveDst)
            {
                return MoveCorner(path.corners[index], anchor);
            }
            anchor = path.corners[index];
        }

        return path.corners[path.corners.Length - 1];
    }

    Vector3 MoveCorner(Vector3 toMove, Vector3 anchor)
    {
        Vector3 movedist = new Vector3();

        for (int index = 0; index < 100; index += 5)
        {
            movedist = Vector3.Lerp(toMove, anchor, index / 100f);

            if (Vector3.Distance(movedist, transform.position) <= maxMoveDst + 0.5f)
            {
                    return movedist;
            }
        }
        return anchor;
    }

    public void NextAction()
    {
        //Moving a unit to target posistion
        if (isUnit)
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
        if (Vector3.Distance(ultimateTarget, transform.position) < inRangeToEngage)
        {//Debug.Log("Reached Target");
            agent.ResetPath();
        }
        else
        {//Debug.Log("Moving to Target");
            CalculatePath();
            MoveUnit();
        }
    }

    private void TargetUnit()
    {
        Combat _combat = GetComponent<Combat>();
        bool didIAttack = false;

        if (_combat.GetCard() != null)
        {
            didIAttack = _combat.Interaction(targetUnit);
        }

        if (didIAttack == false && Vector3.Distance(targetUnit.transform.position, transform.position) > inRangeToEngage)
        {
            //Debug.Log("Chasing Unit");
            CalculatePath();
            MoveUnit();
        }
    }
}