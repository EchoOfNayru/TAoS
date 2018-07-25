using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFragments : MonoBehaviour {

    public float lifetime = 5.0f;
    float lifetimeStart;

    PooledObject pool;

    Rigidbody[] rb;

    Quaternion ORV;

    Vector3 OTP;

    void Start()
    {
        pool = GetComponent<PooledObject>();
        rb = GetComponentsInChildren<Rigidbody>();
        lifetimeStart = lifetime;
    }

    void Update () {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0.0f)
        {
            //transform.position = OTP;
            transform.rotation = ORV;
            foreach (var piece in rb)
            {
                piece.velocity = new Vector3(0, 0, 0);
                piece.transform.position = new Vector3(0, 0, 0);
            }
            lifetime = lifetimeStart;
            pool.returnToPool();   
        }
	}
}
