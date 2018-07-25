using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreholder : MonoBehaviour
{

    // Use this for initialization
    public int score = 0;
    public static Scoreholder instance;

    public int[] highScores = new int[3];
    //public string[] highScoresNames = new string[3];


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        highScores[0] = 5000;
        //highScoresNames[0] = "CODY";
        highScores[1] = 3000;
        //highScoresNames[0] = "GOD";
        highScores[2] = 1000;
        //highScoresNames[0] = "BOB";
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
