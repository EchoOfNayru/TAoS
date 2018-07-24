using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    public Slider health;
    public Slider Throw;
    public GameObject PMenu;

	// Use this for initialization
	void Start ()
    {
        health.value = 1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetMouseButtonDown(KeyCode.Mouse0) && (Throw.value < 1.0f))
        // {

        // }
        gamepause();
        if (PMenu.activeInHierarchy == false)
        {
            Time.timeScale = 1;
        }
	}

   void gamepause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            PMenu.SetActive(true);
        }
    }
}
