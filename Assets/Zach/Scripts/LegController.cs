using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour {

    public int LR; //Left-Right 0-off   1-left  2-right
    public int UD; //Up-Down    0-off   1-up    2-down

    public void PointLegs(int LR, int UD)
    {
        GameObject point = Instantiate(gameObject);
        if (UD == 1)
        {
            point.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
        if (UD == 2)
        {
            point.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }
        if (LR == 1)
        {
            point.transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        if (LR == 2)
        {
            point.transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        if (UD == 1 && LR == 1)
        {
            point.transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 1);
        }
        if (UD == 1 && LR == 2)
        {
            point.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1);
        }
        if (UD == 2 && LR == 1)
        {
            point.transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1);
        }
        if (UD == 2 && LR == 2)
        {
            point.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 1);
        }

        transform.LookAt(point.transform);
        Destroy(point);
    }
}
