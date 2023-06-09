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

    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject PausedPanel;
    [SerializeField] GameObject nextLevelPanel;

    [SerializeField] Button startButton;
    [SerializeField] Button pausedRestartButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button playAgainButton;
    [SerializeField] Button nxtLevelPlayAgain;
    [SerializeField] Button nxtLevel;
    [SerializeField] Button quitButton;

    private void Awake()
    {
        Instance = this;

        startButton.onClick.AddListener(OnStartClicked);
        pausedRestartButton.onClick.AddListener(OnRestart);
        resumeButton.onClick.AddListener(OnResume);
        playAgainButton.onClick.AddListener(OnRestart);
        nxtLevelPlayAgain.onClick.AddListener(OnRestart);
        nxtLevel.onClick.AddListener(OnNxtLevel);
        quitButton.onClick.AddListener(OnQuit);
    }

    void Start()
    {
        PausedPanel.SetActive(false);
        Time.timeScale = 0;
    }

    private void OnNxtLevel()
    {
        Time.timeScale = 1;
        nextLevelPanel.SetActive(false);
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
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void NxtLevel()
    {
        nextLevelPanel.SetActive(true);
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
