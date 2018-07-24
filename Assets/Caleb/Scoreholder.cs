using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreholder : MonoBehaviour
{

    // Use this for initialization
    public int score = 0;
    public static Scoreholder instance;


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
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
