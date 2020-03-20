using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody rb;
    public GameObject impact;
    public GameObject body;
    GameObject _bullet;


	void Start () {
        _bullet = Instantiate(body, transform.position, transform.rotation);
        _bullet.transform.SetParent(transform);
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        rb.velocity = transform.forward * speed;
        StartCoroutine("LifeTime");
	}

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(impact, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
