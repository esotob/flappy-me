using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject readyPanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Texts")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text highScoreText;

    public void ShowReady()
    {
        readyPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        scoreText.gameObject.SetActive(false);
        scoreText.text = "0";
    }

    public void ShowPlaying()
    {
        readyPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowGameOver(int score, int highScore)
    {
        gameOverPanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        finalScoreText.text = "Score: " + score;
        highScoreText.text = "Best: " + highScore;
    }
}