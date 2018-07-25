using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public GameObject[] canvas;
    public GameObject PMenu;

    public Text Score1, Score2, Score3;

    private void Start()
    {
        Scoreholder currentScore = FindObjectOfType<Scoreholder>();
        if (currentScore.score > currentScore.highScores[0])
        {
            currentScore.highScores[2] = currentScore.highScores[1];
            //currentScore.highScoresNames[2] = currentScore.highScoresNames[1];
            currentScore.highScores[1] = currentScore.highScores[0];
            //currentScore.highScoresNames[1] = currentScore.highScoresNames[0];
            currentScore.highScores[0] = currentScore.score;
        }
        else if (currentScore.score > currentScore.highScores[1])
        {
            currentScore.highScores[2] = currentScore.highScores[1];
            //currentScore.highScoresNames[2] = currentScore.highScoresNames[1];
            currentScore.highScores[1] = currentScore.score;
        }
        else if (currentScore.score > currentScore.highScores[2])
        {
            currentScore.highScores[2] = currentScore.score;
        }
    }

    public void StartGame()
    {
        StartCoroutine(DelayLevel("TestScene"));
        FindObjectOfType<Scoreholder>().score = 0;
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
        canvas[2].SetActive(false);
    }

    public void MainMenu()
    {
        FindObjectOfType<Scoreholder>().score = 0;
        StartCoroutine(DelayLevel("Menu"));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void HighScores()
    {
        canvas[0].SetActive(false);
        canvas[2].SetActive(true);
        Score1.text = FindObjectOfType<Scoreholder>().highScores[0].ToString();
        Score2.text = FindObjectOfType<Scoreholder>().highScores[1].ToString();
        Score3.text = FindObjectOfType<Scoreholder>().highScores[2].ToString();
    }

    IEnumerator DelayLevel(string levelname)
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(levelname);
    }
}
