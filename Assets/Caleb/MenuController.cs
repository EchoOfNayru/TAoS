using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject[] canvas;
    public GameObject PMenu;

    public void StartGame()
    {
        StartCoroutine(DelayLevel(""));
    }

    public void Controls()
    {
        canvas[1].SetActive(true);
        canvas[0].SetActive(false);
    }

    public void Menu()
    {
        new WaitForSeconds(.3f);
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
    }

    public void MainMenu()
    {
        StartCoroutine(DelayLevel("Menu"));
    }

    public void Quit()
    {
        Application.Quit();
    }


    IEnumerator DelayLevel(string levelname)
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(levelname);
    }

}
