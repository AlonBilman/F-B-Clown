using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText; // optional UI for best score

    private int currentScore = 0;
    private int highScore = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        // load saved high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        ResetScore();
        UpdateHighScoreDisplay();
    }

    public void AddPoint()
    {
        if (GameManager.Instance.IsGameActive())
        {
            currentScore++;

            // new high score?
            if (currentScore > highScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
                UpdateHighScoreDisplay();
            }

            UpdateScoreDisplay();
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
            scoreText.text = currentScore.ToString();
    }

    private void UpdateHighScoreDisplay()
    {
        if (highScoreText != null)
            highScoreText.text = $"Best Score: {highScore}";
    }
}
