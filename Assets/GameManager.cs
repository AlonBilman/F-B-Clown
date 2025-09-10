using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("References")]
    public GameObject menuCanvas;
    public GameObject gameOverCanvas;
    public GameObject pipeSpawner;
    public Bird bird;

    private bool isGameActive = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // optional
    }

    private void Start()
    {
        menuCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        pipeSpawner.SetActive(false);
        bird.enabled = false;
    }

    public void StartGame()
    {
        menuCanvas.SetActive(false);
        pipeSpawner.SetActive(true);
        bird.enabled = true;
        isGameActive = true;
    }

    public void GameOver()
    {
        pipeSpawner.SetActive(false);
        gameOverCanvas.SetActive(true);
        bird.enabled = false;
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public bool IsGameActive()
    {
        return isGameActive;
    }
}
