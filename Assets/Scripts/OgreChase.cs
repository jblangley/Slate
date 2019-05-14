using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OgreChase : MonoBehaviour
{
    public float lookRadius = 10f;
    public float maxMoveDist = 15f;
    GameObject[] listOfUnits;
    [SerializeField]
    Transform target;
    NavMeshAgent agent;
    Transform StartPos;

    //CharacterCombat combat;

    void Start()
    {
        listOfUnits = GameObject.FindGameObjectsWithTag("Unit");
        agent = GetComponent<NavMeshAgent>();
        StartPos = transform;
        target = StartPos;
        //combat = GetComponent<CharacterCombat>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                //CharacterStats targetStats = target.GetComponent<CharacterStats>();
                //if (targetStats != null)
                //{
                //    combat.Attack(targetStats);
                //}
                FaceTarget();
            }
        }
        CheckForTarget();
    }

    void CheckForTarget()
    {
       // Transform lastTarget = listOfUnits[0].transform;
        for (int i = 0; i < listOfUnits.Length; i++)
        {
            if (Vector3.Distance(listOfUnits[i].transform.position, transform.position) < lookRadius)
            {
                //if (Vector3.Distance(listOfUnits[i].transform.position, transform.position)
                //   < Vector3.Distance(lastTarget.position, transform.position))
                //{
                    //lastTarget = target;
                    target = listOfUnits[i].transform;
                //}
            }
       }
        if (Vector3.Distance(target.position, transform.position) > lookRadius)
        {
            target = StartPos;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxMoveDist);
    }
}
