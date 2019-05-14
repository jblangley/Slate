using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    //This uses the spawners location and helps decide in what unit to spawn and where

    public Transform spawnLocation;
    public GameObject unitToSpawn;
    private bool canSpawn = true;
    //private bool isSpawning = false;

    private void Start()
    {
        //spawnLocation = ;
    }

    public void SpawnUnit()
    {
        if (canSpawn)
        {
            //PlayerController obj = CreateUnit.MakeUnit();
             GameObject newUnit = Instantiate(unitToSpawn, spawnLocation);
            newUnit.transform.parent = null;
            newUnit.transform.localScale = new Vector3(1, 1, 1);
            newUnit.transform.position = spawnLocation.position;
        }
        canSpawn = false;
    }

    public void SetSpawn(bool set)
    {
        canSpawn = set;
    }

    public void SetUnitToBeSpawned(bool set)
    {
        if (canSpawn)
        {
            //isSpawning = true;
            canSpawn = false;
        }
    }
}
