using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectMenu : MonoBehaviour {

    public static UnitSelectMenu Menu;
    public GameObject unitSelectUI;
    public Spawner spawner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnableMenu(Spawner _spawner)
    {
        unitSelectUI.SetActive(true);
        spawner = _spawner;
    }

    public void DisableMenu()
    {
        unitSelectUI.SetActive(false);
    }

    public void SelectUnit(GameObject _unit)
    {
        spawner.SetUnitToBeSpawned(_unit);
        DisableMenu();
    }

}
