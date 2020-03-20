using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    //This uses the spawners location and helps decide in what unit to spawn and where

    public Transform spawnLocation;
    public GameObject unitToSpawn;
    private bool canSpawn = true;
    [SerializeField]
    private int kingdomID;

    private void Start()
    {
        FindObjectOfType<GameManager>().EvTakeTurn += SpawnUnit;
    }

    public void SetKingdomID(int id)
    {
        kingdomID = id;
    }

    void SpawnUnit()
    {
        if (canSpawn)
        {
            GameObject newUnit = Instantiate(unitToSpawn, spawnLocation);
            newUnit.transform.parent = null;
            newUnit.transform.localScale = new Vector3(1, 1, 1);
            newUnit.transform.position = spawnLocation.position;
            UnitBaseStats stats = newUnit.GetComponent<UnitBaseStats>();
            stats.kingdomID = kingdomID;
        }
        canSpawn = false;
    }

    public void SetSpawn(bool set)
    {
        canSpawn = set;
    }

    public void SetUnitToBeSpawned(GameObject _unit)
    {
        if (_unit != null)
        {
            unitToSpawn = _unit;
        }
        canSpawn = true;
    }
}
