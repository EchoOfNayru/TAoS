using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    public GameObject remains;
    Vector3 currentSpeed;

    Rigidbody rb;

    GameObject HammerPool;
    ObjectPool pool;

    bool hasSSpawned = false;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    void Awake()
    {
        HammerPool = GameObject.FindGameObjectWithTag("HammerPool");
        pool = HammerPool.GetComponent<ObjectPool>();
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

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Hammer")
        {
            gameObject.GetComponent<MeshCollider>().enabled = false;
            GameObject pieces = pool.getObject();/*Instantiate(remains, transform.position, transform.rotation);*/
            pieces.transform.position = transform.position;
            pieces.transform.rotation = transform.rotation;
            Rigidbody[] piecesRBs = pieces.GetComponentsInChildren<Rigidbody>();

            foreach (var piece in piecesRBs)
            {
                piece.velocity = currentSpeed;
            }

            // destroy the unbroken object
            Destroy(transform.root.gameObject);
        }

        else if (collision.collider.gameObject.tag == "Hammer" /*|| collision.collider.gameObject.tag == "HammerFragment")*/
                  && hasSSpawned == false)
        {
            gameObject.GetComponent<MeshCollider>().enabled = false;
            hasSSpawned = true;
            GameObject pieces = Instantiate(remains, transform.position, transform.rotation);
            Rigidbody[] piecesRBs = pieces.GetComponentsInChildren<Rigidbody>();

            foreach (var piece in piecesRBs)
            {
                piece.velocity = currentSpeed;
            }
            // destroy the unbroken object
            Destroy(transform.root.gameObject);
            hasSSpawned = false;
        }
    }
}
