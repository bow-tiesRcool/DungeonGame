using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    //public AudioSource sound;
    //public AudioClip music;
    //public AudioClip gameOver;
    //public Text scoreUI;
    //public Text highScoreUI;
    //public Text gameOverUI;
    //public Text MultiplierUI;
    public Text Lives;
    public Transform quitScreen;
    public Transform gameOverScreen;

    public int score = 0;
    public float playerSpeed = 3;
    private int playerLife;
    private int currentLife;
    public PlayerController player;


    void Awake()
    {
        if (instance == null)
        {
            Debug.Log("yeas!");
            instance = this;
        }
        else
        {
            Debug.Log("Nooo");
        }
    }

    void Start()
    {
        //instance.highScoreUI.text = "HighScore: " + PlayerPrefs.GetInt("highScore");
        //sound = GetComponent<AudioSource>();
        //scoreUI.text = "Score: " + score;
        //instance.sound.clip = instance.music;
        //instance.sound.Play();
        playerLife = player.life;
        currentLife = playerLife;
        instance.Lives.text = "Lives: " + currentLife;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            quitScreen.gameObject.SetActive(true);
        }
        //HighScore();
    }

    public static void Points(int multi, int points)
    {
        //instance.StartCoroutine("MultiplierUITimer");
        //instance.multiScore += multi;
        //int Score = points * instance.multiScore;
        //instance.score += Score;
        //instance.scoreUI.text = "Score: " + instance.score;
    }

    public static void HighScore()
    {
        //if (instance.score > instance.highScore)
        //{
        //    instance.highScore = instance.score;
        //}
        //if (instance.highScore > PlayerPrefs.GetInt("highScore"))
        //{
        //    instance.highScoreUI.text = "highScore: " + instance.highScore;
        //}
    }
    public static void HighScoreSaver()
    {
        //if (PlayerPrefs.HasKey("highScore") == true)
        //{
        //    if (instance.highScore > PlayerPrefs.GetInt("highScore"))
        //    {
        //        int newHighScore = instance.highScore;
        //        PlayerPrefs.SetInt("highScore", newHighScore);
        //        PlayerPrefs.Save();
        //    }
        //}
        //else
        //{
        //    int newHighScore = instance.highScore;
        //    PlayerPrefs.SetInt("highScore", newHighScore);
        //    PlayerPrefs.Save();
        //}
    }

    public void LooseLife()
    {
        currentLife--;
        if (currentLife >= 1)
        {
            Lives.text = "Lives: " + currentLife;
        }
        else
        {
            Time.timeScale = 0;
            gameOverScreen.gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        AudioManager.PlayEffect("Death", 1, 1);
        Time.timeScale = 0;
        HighScoreSaver();
        gameOverScreen.gameObject.SetActive(true);
        //   Return to the main menu is handled by the SceneController;
    }

    public void ResetGame()
    {
        currentLife = playerLife;
    }

    public void ExitQuitScreen()
    {
        Time.timeScale = 1;
        quitScreen.gameObject.SetActive(false);
    }

    IEnumerator MultiplierUITimer()
    {
        //instance.MultiplierUI.text = ("Multiplier X" + instance.multiScore);
        //instance.MultiplierUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        //instance.MultiplierUI.gameObject.SetActive(false);
    }
}

