using UnityEngine;

public class PipeSlider : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float offscreenOffset = 1f;
    private float leftEdge;
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - offscreenOffset;
    }
    private void Update()
    {
        if (!GameManager.Instance.IsGameActive()) return;
        // slide pipe left
        transform.position += Vector3.left * speed * Time.deltaTime;
        // deactivate pipe if out of frame and set it inactive for pooling
        if (transform.position.x < leftEdge)
        {
            gameObject.SetActive(false); 
        }
    }
}
