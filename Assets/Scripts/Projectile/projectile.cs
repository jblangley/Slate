using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject target;

    void Update () {
        if (Input.GetButtonDown("Fire3"))
        {
            Instantiate(bullet, firePoint.position, transform.rotation);
        }
        
	}

    public void Fire()
    {
        Instantiate(bullet, firePoint.position, transform.rotation);
    }

    public void Fire(Vector3 _firePoint)
    {
        Instantiate(bullet, firePoint.position + _firePoint, transform.rotation);
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}
