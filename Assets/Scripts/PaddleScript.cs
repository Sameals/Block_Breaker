using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float maxLeftScreen;
    [SerializeField] float maxRightScreen;
    [SerializeField] PowerUp extraLives;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

        if(transform.position.x < maxLeftScreen)
        {
            transform.position = new Vector2(maxLeftScreen, transform.position.y);
        }

        if(transform.position.x > maxRightScreen)
        {
            transform.position = new Vector2(maxRightScreen, transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ExtraLife"))
        {
            Debug.Log("add health");
            ApplyPowerUp(collision.gameObject);
            Destroy(collision.gameObject);

        }
    }
    private void ApplyPowerUp(GameObject gameObject)
    {
        UIManager.Instance.updateLives(extraLives.Amount);
    }
}
