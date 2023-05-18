using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public static BallScript instance;

    [SerializeField] float ballForce = 500;
    [SerializeField] Transform ballPosition;
    [SerializeField] Transform explosion;
    [SerializeField] Transform powerup;
    [SerializeField] LevelGenerator levelGenerator;

    bool isGamestarted = false;
    Rigidbody2D rb;
    int livesChange = -1;
    AudioSource audio;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
       CheckGameStarted();

        addBallForce();
    }
    private void CheckGameStarted()
    {
        if (!isGamestarted)
        {
            transform.position = ballPosition.position;

        }
    }

    private void addBallForce()
    {
        if (Input.GetButtonDown("Jump") && !isGamestarted)
        {
            isGamestarted = true;
            rb.AddForce(Vector2.up * ballForce);
            
        }
    }

    //decrease lives
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottom"))
        {
            Debug.Log("ball hit the ground");
            rb.velocity = Vector2.zero;
            isGamestarted = false;
            LivesScript.instance.updateLives(livesChange);
            ResetPosition();
        }
    }

    //break bricks

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            BrickScript brickScript = collision.gameObject.GetComponent<BrickScript>();
            if (brickScript.hitToBreak > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {
                int randomChance = Random.Range(1, 100);
                if (randomChance < 10)
                {
                    Instantiate(powerup, collision.transform.position, collision.transform.rotation);
                }

                Transform newExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
                Destroy(newExplosion.gameObject, 1f);

                ScoreManagement.instance.UpdateScore(brickScript.points);

                levelGenerator.UpdateNoOfBricks();

                Destroy(collision.gameObject);
            }

            audio.Play();
        }
    }

    public void ResetPosition()
    {
        transform.position = ballPosition.position;
        rb.velocity = Vector2.zero;
        isGamestarted = false;
        addBallForce();
    }
}
