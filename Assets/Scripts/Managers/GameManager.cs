using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject menuCanvas;
    public GameObject gameOverCanvas;
    public GameObject pipeSpawner;
    public GameObject bird;

    private enum GameState { Menu, Playing, GameOver }
    private GameState currentState;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        SetState(GameState.Menu);
    }

    private void Update()
    {
        if (currentState == GameState.Menu && Input.anyKeyDown)
        {
            StartGame();
        }
        else if (currentState == GameState.GameOver && Input.anyKeyDown)
        {
            RestartGame();
        }
    }

    public void StartGame()
    {
        ScoreManager.Instance.ResetScore();
        menuCanvas.SetActive(false);
        pipeSpawner.SetActive(true);
        bird.SetActive(true);
        SetState(GameState.Playing);
    }

    public void GameOver()
    {
        pipeSpawner.SetActive(false);
        gameOverCanvas.SetActive(true);
        bird.SetActive(false);
        SetState(GameState.GameOver);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool IsGameActive()
    {
        return currentState == GameState.Playing;
    }

    private void SetState(GameState newState)
    {
        currentState = newState;
        menuCanvas.SetActive(newState == GameState.Menu);
        gameOverCanvas.SetActive(newState == GameState.GameOver);
        pipeSpawner.SetActive(newState == GameState.Playing);
        bird.SetActive(newState == GameState.Playing);
    }
}
