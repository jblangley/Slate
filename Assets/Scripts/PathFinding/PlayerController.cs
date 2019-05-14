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
    public float inRangeDst = 2f;
    public bool isEngaged = false;
    public int moveStatus = 0;
    public bool isGuarding = false;
    public bool isDodging = false;
    public bool isAttacking = false;
    public bool isSlateAttacking = false;

    LineRenderer line;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ultimateTarget = transform.position;
        
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
        if (targetUnit == null && ultimateTarget == new Vector3(0,0,0))
        {
            isUnit = false;
            ultimateTarget = transform.position;
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
        Vector3 anchor = this.transform.position;
        for (int index = 0; index < path.corners.Length; index++)
        {
            Vector3 corner = path.corners[index];
            float distance = Vector3.Distance(anchor, corner);
            if (distance > maxMoveDst)
            {//Debug.Log("Corner index is " + index + ": " + "  " + path.corners[index]);
                return MoveCorner(corner, anchor);
            }
            anchor = corner;
        }        //Debug.Log(this.name);
        return path.corners[path.corners.Length - 1];
    }

    Vector3 MoveCorner(Vector3 toMove, Vector3 anchor)
    {
        Vector3 movedist = new Vector3();
        bool hasMoved = false;
        float distance = Vector3.Distance(toMove, transform.position);
        for (int index = 0; index < 100; index+=5)
        {
                if (distance >= maxMoveDst + 0.5f)
                {
                    movedist = Vector3.Lerp(toMove, anchor, index / 100f);
                    hasMoved = true;
                }
                else if (hasMoved)
                {
                    return movedist;
                }
                distance = Vector3.Distance(movedist, transform.position);
        }
        return anchor;
    }

    //private void OnMouseEnter()
    //{
    //    Debug.Log("Mouse on");
        
    //    if (isUnit)
    //    {
    //        //line = path.corners;
    //        Debug.Log(targetUnit);
    //        for (int index = 0; index < path.corners.Length; index++)
    //        {
    //            line.numCornerVertices = path.corners.Length;
    //            //line = path.corners[index]; 
    //        }
            
    //    }
    //    else
    //    {
    //        Debug.Log(ultimateTarget);
    //    }
    //}

    //private void OnMouseExit()
    //{
    //    Debug.Log("Mouse Off");
    //}
}