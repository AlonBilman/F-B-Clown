using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;

    private int currentScore = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        ResetScore();
    }

    public void AddPoint()
    {
        if (GameManager.Instance.IsGameActive())
        {
            currentScore++;
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
}
