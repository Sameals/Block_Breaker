using UnityEngine;

[System.Serializable]
public class BrickInfo
{
    public GameObject brickPrefab;
   public int brickCount;
}

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Vector2 size;
    [SerializeField] Vector2 offset;
    [SerializeField] BrickInfo[] bricks;

    int currentLevel = 1;
    int totalLevels = 10;

    int noOfBricks;
    GameObject newBrick;

    void Start()
    {
        GenerateLevel(currentLevel);
    }

    void GenerateLevel(int level)
    {
        noOfBricks = 0;

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                int randomIndex = Random.Range(0, bricks.Length);
                GameObject brickPrefab = bricks[randomIndex].brickPrefab;
                int brickCount = bricks[randomIndex].brickCount;

                for (int k = 0; k < brickCount; k++)
                {
                    newBrick = Instantiate(brickPrefab, transform);
                    newBrick.transform.position = transform.position + new Vector3(i * offset.x, j * offset.y, 0);
                    noOfBricks++;
                }
            }
        }
        if (currentLevel > 1)
        {
            // Reset the score when advancing to the next level
            ScoreManagement.instance.ResetScore();
        }
    }

    public void UpdateNoOfBricks()
    {
        noOfBricks--;

        if (noOfBricks <= 0)
        {
            Debug.Log("All bricks destroyed");

            if (currentLevel < totalLevels)
            {
                UIManager.Instance.NxtLevel();
                BallScript.instance.ResetPosition();
                currentLevel++;
                GenerateLevel(currentLevel);
            }
            else
            {
                Debug.Log("Game completed");
                UIManager.Instance.GameOver();
            }
        }
    }
}