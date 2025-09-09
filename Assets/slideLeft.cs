using UnityEngine;

public class SlideLeft : MonoBehaviour
{
    public float speed = 2f; 

    void Update()
    {
        // move the pipes left in a steady pace 
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
