using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour
{
    public Camera cam;
    public int MBLeft = 0;
    public int MBRight = 1;
    PlayerController gO;
    public GameObject[] allUnits;
    public float speed = 5;
    Spawner spawner;

    void Start()
    {
        cam = GetComponent<Camera>();
        allUnits = GameObject.FindGameObjectsWithTag("Unit");
        
    }

    void Update()
    {
        SelectAnUnit();
        SelectTarget();
        MoveUnits();
        MoveCamera();
    }

    void SelectAnUnit()
    {
        if (Input.GetMouseButtonDown(MBLeft))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //if it hits something with an agent set agent to it
                if (hit.collider.gameObject.tag == "Unit")
                {
                    gO = hit.collider.gameObject.GetComponent<PlayerController>();
                }
                if (hit.collider.gameObject.tag == "Spawner")
                {
                    //gO = hit.collider.gameObject.GetComponent<PlayerController>();
                    //spawn one unit
                    spawner = hit.collider.gameObject.GetComponent<Spawner>();
                    spawner.SetSpawn(true);
                }
                Debug.Log("Click");
            }

        }
    }

    void SelectTarget()
    {
        if (Input.GetMouseButtonDown(MBRight))
        {
            //If it is another agent set the current one to follow
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {

                if (hit.collider.gameObject.tag == "Unit")
                {
                    gO.SetTargetPath(hit.collider.gameObject);
                }
                else
                {
                    gO.SetTargetPath(hit.point);
                }
            }
        }
    }

    void MoveUnits()
    {
        if (Input.GetButtonDown("Jump"))
        {
            allUnits = GameObject.FindGameObjectsWithTag("Unit");

            foreach (GameObject unit in allUnits)
            {
                if (unit != null)
                {
                    DecideNextAction temp = unit.GetComponent<DecideNextAction>();
                    temp.NextAction();
                }
            }

            if (spawner != null)
            {
                spawner.SpawnUnit();
            }
            //Maybe learn events and have the actions happen all at once
        }
    }

    

    void MoveCamera()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            cam.transform.localPosition += new Vector3(0, 0, speed * Input.GetAxis("Horizontal")) * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            cam.transform.localPosition += -(new Vector3(speed * Input.GetAxis("Vertical"), 0, 0) * Time.deltaTime);
        }
    }
}
