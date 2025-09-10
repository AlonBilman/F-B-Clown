using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When the bird hits something, trigger Game Over
        gameManager.GameOver();
    }
}
