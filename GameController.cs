using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public AudioSource musicSource;

    public Text winText;
    public Text ScoreText;
    public Text livesText;
    public Text restartText;
    public Text gameOverText;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public float score;
    public float lives;



    private bool gameOver;
    private bool restart;
    
    
    
    

    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        lives = 3;
        StartCoroutine(SpawnWaves());
        UpdateScore();
        SetLivesText();
       
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }


        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }



    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'T' for Restart";
                restart = true;
                break;
            }
        }
    }

    


    public void AddScore(int newScoreValue)
    {

        score += newScoreValue;
        UpdateScore();
        
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            Destroy(gameObject);
            gameOverText.text = "Game Over!";
        }
    }


    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            winText.text = "You win! Game created by Aaron Martin";
            gameOver = true;
            restart = true;
            musicSource.clip = musicClipOne;
            musicSource.Play();
       

        }

        else
        {
            SetLivesText();
        }
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        musicSource.clip = musicClipTwo;
        musicSource.Play();

       
    }

   
}