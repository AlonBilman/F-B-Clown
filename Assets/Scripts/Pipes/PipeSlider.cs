using UnityEngine;

public class SlideLeft : MonoBehaviour
{
    public float speed = 1.5f; 

    void Update()
    {
        if (GameManager.Instance.IsGameActive())
        {
            // move the pipes left in a steady pace 
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
