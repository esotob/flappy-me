using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Ready,
        Playing,
        GameOver
    }

    public static GameManager Instance { get; private set; }

    public GameState State { get; private set; }

    [SerializeField] private UIManager ui;

    private const string HighScoreKey = "HighScore";

    private int score;

    [Header("Difficulty")]
    [SerializeField] private float baseSpeed = 3f;
    [SerializeField] private float maxSpeed = 5.5f;
    [SerializeField] private int scoreForMaxSpeed = 25;
    [SerializeField] private float pipeSpacing = 5.4f;
    [SerializeField] private CameraShake cameraShake;

    public float PipeSpeed
    {
        get
        {
            float t = Mathf.Clamp01((float)score / scoreForMaxSpeed);
            return Mathf.Lerp(baseSpeed, maxSpeed, t);
        }
    }

    public float SpawnInterval
    {
        get { return pipeSpacing / PipeSpeed; }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Time.timeScale = 1f;
        State = GameState.Ready;
    }

    private void Start()
    {
        ui.ShowReady();
    }

    public void StartGame()
    {
        if (State != GameState.Ready)
        {
            return;
        }

        State = GameState.Playing;
        ui.ShowPlaying();
    }

    public void AddScore()
    {
        if (State != GameState.Playing)
        {
            return;
        }

        score++;
        ui.UpdateScore(score);
    }

    public void GameOver()
    {
        if (State != GameState.Playing)
        {
            return;
        }

        State = GameState.GameOver;

        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            PlayerPrefs.Save();
        }

        ui.ShowGameOver(score, highScore);
        ui.ShowGameOver(score, highScore);
        cameraShake.Shake();
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}