using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    public static ScoreManagement instance;

    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
        
    }
    private void Start()
    {
        scoreText.text = "Score : " + score;
    }
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }
    public void UpdateScore(int scorePoints)
    {
        score += scorePoints;
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {
        scoreText.text = "Score : " + score;
    }
}
