using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour {
    public int score;
    public Scoreholder total;
    int counter;
	
    private void OnCollisionEnter(Collision collision)
    {
        if (counter >= 1)
        {
            return;
        }
        if (gameObject.tag == "Hammer")
        {
            total.score += score;
            counter++;
        }
        
    }
}
