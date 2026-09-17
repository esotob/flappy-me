using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsGameOver { get; private set; }

    private int score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Time.timeScale = 1f;
    }

    public void AddScore()
    {
        if (IsGameOver)
        {
            return;
        }

        score++;
        Debug.Log("Score: " + score);
    }

    public void GameOver()
    {
        if (IsGameOver)
        {
            return;
        }

        IsGameOver = true;
        Debug.Log("Game Over. Final score: " + score);
        Time.timeScale = 0f;
    }
}