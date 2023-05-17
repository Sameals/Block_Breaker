using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Vector2 size;
    [SerializeField] Vector2 offset;
    [SerializeField] GameObject brickPrefab;

    int noOfBricks;
    GameObject newBrick;

    void Start()
    {
        noOfBricks = 0;

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                newBrick = Instantiate(brickPrefab, transform);
                newBrick.transform.position = transform.position + new Vector3( i * offset.x, j * offset.y, 0);
                noOfBricks++;
            }
        }
    }
    public void UpdateNoOfBricks()
    {
        noOfBricks--;
        if (noOfBricks <= 0)
        {
            Debug.Log("All bricks destroyed");
            UIManager.Instance.GameOver();
        }
    }
}
