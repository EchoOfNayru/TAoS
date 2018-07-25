using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardScript : MonoBehaviour {

    public float speed;
    public bool upDown;
    public float turnTimerMax;
    public float turnTimer;
    public int currentPoint;
    public Vector3 pointA, pointB;

    void Start()
    {
        turnTimer = turnTimerMax;
    }

    void Update()
    {
        turnTimer -= Time.deltaTime;
        if (turnTimer <= 0)
        {
            if (currentPoint == 1)
            {
                transform.LookAt(pointB);
                currentPoint = Random.Range(2, 1000000);
            }
            else
            {
                transform.LookAt(pointA);
                currentPoint = 1;
            }
            turnTimer = turnTimerMax;
        }
    }

    void FixedUpdate()
    {
        if (upDown)
        {
            if (currentPoint == 1)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
            }
        }
        else
        {
            if (currentPoint == 1)
            {
                transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            }
        }
    }
}
