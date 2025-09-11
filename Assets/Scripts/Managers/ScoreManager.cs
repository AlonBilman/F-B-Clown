using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

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
        hideCurrGameScore();
    }

    private void Update()
    {
        // When the game becomes active, show the score
        if (GameManager.Instance.IsGameActive() && !scoreText.gameObject.activeSelf)
        {
            scoreText.gameObject.SetActive(true);
        }
    }

    public void AddPoint()
    {
        if (GameManager.Instance.IsGameActive())
        {
            currentScore++;

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
        hideCurrGameScore();
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

    private void hideCurrGameScore()
    {
        if (scoreText != null)
            scoreText.gameObject.SetActive(false);
    }
}
