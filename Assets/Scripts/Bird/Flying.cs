using UnityEngine;

public class BirdFlight : MonoBehaviour
{
    public float flapForce = 5f;   
    public float fallTilt = -20f; 
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // flap on space, mouse click, or up arrow
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            rb.linearVelocity = Vector2.up * flapForce;

        // when the bird falls I wanted a little tilt, so here it is
        if (rb.linearVelocity.y < 0f)
            transform.rotation = Quaternion.Euler(0f, 0f, fallTilt);
        else
            transform.rotation = Quaternion.identity;
    }
}
