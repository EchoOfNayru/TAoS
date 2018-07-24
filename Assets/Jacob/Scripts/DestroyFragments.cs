using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFragments : MonoBehaviour {

    public float lifetime = 5.0f;

    PooledObject pool;

    void Start()
    {
        pool = GetComponent<PooledObject>();
    }

    void Update () {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0.0f)
        {
            pool.returnToPool();   
        }
	}
}
