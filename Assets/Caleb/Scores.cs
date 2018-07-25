using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour {
    public int score;
    public Scoreholder total;
    int counter;

    private void Start()
    {
        total = FindObjectOfType<Scoreholder>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (counter >= 1)
        {
            return;
        }
        else if (collision.collider.tag == "Hammer")
        {
            Debug.Log("points");
            total.score += score;
            counter++;
        }
        
    }
}
