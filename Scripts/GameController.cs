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
    public int wavetype;
    public bool debug;



    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text highscoreText;

    private bool gameOver;
    private bool restart;
    private int score;
    private string path;


    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        highscoreText.text = "";
        path = Application.dataPath + "/test.txt";
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
            if (debug)
            {
                Debug.Log("spawnWaves startet");
            }
            for (int i = 0; i < totalNumberOfWaves; i++)
            {
                if (debug)
                {
                    Debug.Log("forloop startet");
                }
                switch (wavetype)
                {
                    case 1:
                        Console.WriteLine("Arrow wawe");
                        arrowFormation();
                        break;
                    case 2:
                        Console.WriteLine("random wawe");
                        randomWawee(10);
                        break;
                    default:
                        Console.WriteLine("Default case");
                        randomWawee(10);
                        break;
                }
                yield return new WaitForSeconds(waveWait);
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

  
        System.IO.StreamReader file =
            new System.IO.StreamReader(path);
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
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(score);
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public void arrowFormation()
    {
        float xAxis = UnityEngine.Random.Range(-spawnValues.x, spawnValues.x);


        Vector3 spawnPosition = new Vector3(xAxis + 0, spawnValues.y, spawnValues.z + 0);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(hazard, spawnPosition, spawnRotation);

        Vector3 spawnPosition2 = new Vector3(xAxis -1, spawnValues.y, spawnValues.z + 1);
        Quaternion spawnRotation2 = Quaternion.identity;
        Instantiate(hazard, spawnPosition2, spawnRotation);

        Vector3 spawnPosition3 = new Vector3(xAxis -2, spawnValues.y, spawnValues.z + 2);
        Quaternion spawnRotation3 = Quaternion.identity;
        Instantiate(hazard, spawnPosition3, spawnRotation);

        Vector3 spawnPosition4 = new Vector3(xAxis -3, spawnValues.y, spawnValues.z + 3);
        Quaternion spawnRotation4 = Quaternion.identity;
        Instantiate(hazard, spawnPosition4, spawnRotation);

        Vector3 spawnPosition5 = new Vector3(xAxis + 1, spawnValues.y, spawnValues.z + 1);
        Quaternion spawnRotation5 = Quaternion.identity;
        Instantiate(hazard, spawnPosition5, spawnRotation);

        Vector3 spawnPosition6 = new Vector3(xAxis + 2, spawnValues.y, spawnValues.z + 2);
        Quaternion spawnRotation6 = Quaternion.identity;
        Instantiate(hazard, spawnPosition6, spawnRotation);

        Vector3 spawnPosition7 = new Vector3(xAxis + 3, spawnValues.y, spawnValues.z + 3);
        Quaternion spawnRotation7 = Quaternion.identity;
        Instantiate(hazard, spawnPosition7, spawnRotation);

    }
    public void randomWawee(int numberOfWaves)
    {
        numberOfWaves = numberOfWaves + 1;
        for (int i = 1; i < hazardCount; i++)
        {
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            
        }
    }
}
