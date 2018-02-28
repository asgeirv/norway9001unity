using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject player;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int totalNumberOfWaves;
    public int ammoValue;
   
    GameObject[] waves;

 
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text highscoreText;

    private bool gameOver;
    private bool restart;
    private int score;
    private string path;

    public PlayerInventory pl;
    

    void Start()
    {


        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        highscoreText.text = "";
        path = Application.dataPath + "/test.txt";
        score = 0;
        Instantiate(player, transform.position, transform.rotation);
        UpdateScore();
        StartCoroutine( SpawnWaves());
        pl = new PlayerInventory();
        waves = GameObject.FindGameObjectsWithTag("Waves");
        totalNumberOfWaves = 0;
        waves[0].SetActive(true);
        foreach(GameObject w in waves)
        {
            w.SetActive(false);
            totalNumberOfWaves = totalNumberOfWaves + 1;
        }
        
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
    /**
        * Teller antall enemies,
        * spawner en ny wave når enemies i nåverende wave er 0,
        * hindrer neste wave i å spawne dersom player døyr.
        * var w: index i arrayet waves
        * var e: antall aktive enemies i en wave
        * */
    IEnumerator SpawnWaves()
    {
       int w = 0;
           
        while (!restart)
        {
            yield return new WaitForSeconds(1);
            
            int e = 0;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject g in enemies)
            {
                e = e + 1;
                
            }
           
            if (e == 0 && w <= totalNumberOfWaves)
            {
                if (w == (totalNumberOfWaves) && e == 0)
                 {

                    GameOver("Asgeir is a pro");
                    break;
                }
                if(!restart)
                {
                    waves[w].SetActive(true);
                }

                w = w + 1;
            }   
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

    public void AddAmmo()
    {
        pl.AddAmmo(ammoValue);
    }

    /**
     * Finner høyeste score opnått 
     * og viser den på skjermen
     * */
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
    /**
     * Printer den oppnådde scoren i et tekstdokument
     * */
    void PrintScore()
    {
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(score);
        }
    }

    public void GameOver(String t)
    {
        gameOverText.text = t;
        restartText.text = "Press 'R' to restart";
        restart = true;
        
    }
}
