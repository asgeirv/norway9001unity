using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int totalNumberOfWaves;



    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text highscoreText;

    private bool gameOver;
    private bool restart;
    private int score;


    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        highscoreText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    private void Update()
    {
        if (restart)
        {                  
           if (Input.GetKeyDown(KeyCode.R))
            {
                
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        int numberOfWaves = 0;
        bool continueGame = true;

        while (continueGame)
        {
            numberOfWaves = numberOfWaves + 1;
            for (int i = 1; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            if (gameOver || numberOfWaves == totalNumberOfWaves)
            {
                restartText.text = "Press 'R' to restart";
                restart = true;
                continueGame = false;
            }
            yield return new WaitForSeconds(waveWait);
        }
        PrintScore();
        PrintHighscore();

    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void PrintHighscore()
    {
        string line;
        int highscore = 0;
        int read;

        // Read the file and display it line by line.  
        System.IO.StreamReader file =
            new System.IO.StreamReader(@"C:\Users\Kristian\Documents\SpaceShooter\test.txt");
        while ((line = file.ReadLine()) != null)
        {
            read = Int32.Parse(line);
            if (read >= highscore)
            {
                highscore = read;

            }

        }
        highscoreText.text = "Highscore: " + highscore.ToString();
        file.Close();
    }

    void PrintScore()
    {
        using (StreamWriter sw = File.AppendText(@"C:\Users\Kristian\Documents\SpaceShooter\test.txt"))
        {
            sw.WriteLine(score);
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
