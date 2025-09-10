using UnityEngine;

public class Bird : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // when the bird hits something, trigger Game Over
        GameManager.Instance.GameOver();
    }
}
