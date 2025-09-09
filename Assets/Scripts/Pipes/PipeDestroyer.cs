using UnityEngine;

public class PipeDestroyer : MonoBehaviour
{
    private float leftEdge;

    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        //-1f so the destroyer is off screen 
    }

    void Update()
    {
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
