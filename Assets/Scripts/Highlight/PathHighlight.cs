using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathHighlight : MonoBehaviour {

    LineRenderer line;
   // var target;
   NavMeshAgent agent;

	void GetPath()
    {
        line.SetPosition(0, transform.position);
        DrawPath(agent.path);
    }

    void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2)
        {
            return;
        }

       // line.positionCount(path.corners.Length);

        for (int index = 0; index < path.corners.Length; index++)
        {
            line.SetPosition(index, path.corners[index]);
        }
    }
}
