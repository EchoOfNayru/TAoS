using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    public GameObject remains;
    Vector3 currentSpeed;

    Rigidbody rb;


	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        currentSpeed = rb.velocity;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(remains, transform.position, transform.rotation);
        //    Rigidbody remainsRB = remains.GetComponent<Rigidbody>();
        //    remainsRB.velocity = currentSpeed;
        //    Destroy(gameObject);
        //}
	}

    void OnCollisionEnter()
    {
        Instantiate(remains, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
