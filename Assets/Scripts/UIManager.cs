using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] int lives;
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject PausedPanel;

    [SerializeField] Button startButton;
    [SerializeField] Button pausedRestartButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button playAgainButton;
    [SerializeField] Button quitButton;

    private void Awake()
    {
        Instance = this;

        startButton.onClick.AddListener(OnStartClicked);
        pausedRestartButton.onClick.AddListener(OnRestart);
        resumeButton.onClick.AddListener(OnResume);
        playAgainButton.onClick.AddListener(OnRestart);
        quitButton.onClick.AddListener(OnQuit);
    }
    void Start()
    {
        PausedPanel.SetActive(false);
        Time.timeScale = 0;
        livesText.text = "Lives : " + lives;
        scoreText.text = "Score : " + score;
    }

    void OnStartClicked()
    {
        Time.timeScale = 1;
        mainMenuPanel.SetActive(false);
    }

    private void OnQuit()
    {
        Application.Quit();
    }

    private void OnRestart()
    {
        Time.timeScale = 1;
        GameOverPanel.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    private void OnResume()
    {
        Time.timeScale = 1;
        PausedPanel.SetActive(false);
    }

    public void updateLives(int livesChange)
    {
        lives += livesChange;

        //check no lives left and trigger the end of the game
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives : " + lives;
    }

    public void UpdateScore(int scorePoints)
    {
        score += scorePoints;

        scoreText.text = "Score : " + score;
    }

    public void GameOver()
    {
        //isGameOver = true;
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PausedPanel.SetActive(true);
        }
    }
}
