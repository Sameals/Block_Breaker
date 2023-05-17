using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] float ballForce = 400;
    [SerializeField] Transform ballPosition;
    [SerializeField] Transform explosion;
    [SerializeField] Transform powerup;
    [SerializeField] LevelGenerator levelGenerator;

    bool isGamestarted = false;
    Rigidbody2D rb;
    int livesChange = -1;
    AudioSource audio;

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
            UIManager.Instance.updateLives(livesChange);
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
                int randomChance = Random.Range(1, 101);
                if (randomChance < 20)
                {
                    Instantiate(powerup, collision.transform.position, collision.transform.rotation);
                }

                Transform newExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
                Destroy(newExplosion.gameObject, 1f);

                UIManager.Instance.UpdateScore(brickScript.points);

                levelGenerator.UpdateNoOfBricks();

                Destroy(collision.gameObject);
            }
            audio.Play();
        }
    }
}
