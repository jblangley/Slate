using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.EventSystems;

public class UnitMover : MonoBehaviour
{
    public Camera cam;
    public int MBLeft = 0;
    public int MBRight = 1;
    public float speed = 5;
    GameManager manager;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (manager == null)
        {
            manager = FindObjectOfType<GameManager>();
        }
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
                if (hit.collider.gameObject.tag == "Unit")
                {
                    manager.SelectUnit(hit.collider.gameObject.GetComponent<Deck>());
                }
                else if (hit.collider.gameObject.tag == "Spawner")
                {
                    //UnitSelectMenu.Menu.EnableMenu(hit.collider.gameObject.GetComponent<Spawner>());
                    manager.SelectSpawner(hit.collider.gameObject.GetComponent<Spawner>());
                }
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
                    manager.SelectTarget(hit.collider.gameObject);
                }
                else
                {
                    manager.SelectPoint(hit.point);
                }
            }
        }
    }

    void MoveUnits()
    {
        if (Input.GetButtonDown("Jump"))
        {
            manager.NextAction();
            manager.CheckWin();
            //Maybe learn events and have the actions happen all at once
        }
    }

    void MoveCamera()
    {
        Vector3 camMove = new Vector3();
        float temp = 1f;
        if (Input.GetAxis("Vertical") != 0)
        {
            camMove += new Vector3(0, 0, Input.GetAxis("Vertical")) * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            camMove += -(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime);
        }
        cam.transform.position += (Vector3.ClampMagnitude(camMove, temp)) * speed;
    }
}
