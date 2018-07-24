using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour {

    Scoreholder tim;
    public Text ending;
    // Use this for initialization
    void Start()
    {
        tim = FindObjectOfType<Scoreholder>();
        ending.text = tim.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tim = FindObjectOfType<Scoreholder>();
        ending.text = tim.score.ToString();
    }
}
