using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesScript : MonoBehaviour
{
    public static LivesScript instance;

    [SerializeField] int lives;
    [SerializeField] TextMeshProUGUI livesText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        livesText.text = "Lives : " + lives;
    }

    public int GetLives()
    {
        return lives;
    }

    public void updateLives(int livesChange)
    {
        lives += livesChange;
        
        //check no lives left and trigger the end of the game
        if (lives <= 0)
        {
            lives = 0;
            UIManager.Instance.GameOver();
        }

        livesText.text = "Lives : " + lives;
    }
}
