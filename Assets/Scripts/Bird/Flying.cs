using UnityEngine;

public class BirdFlight : MonoBehaviour
{
    public float flapForce = 5f;
    public float fallTilt = -20f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Jump(); //Jump at the start
    }
    void Update()
    {
        if (GameManager.Instance.IsGameActive())
        {
            // flap on space, mouse click, or up arrow
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
                Jump();
        }

        // when the bird falls I wanted a little tilt, so here it is
        if (rb.linearVelocity.y < 0f)
            transform.rotation = Quaternion.Euler(0f, 0f, fallTilt);
        else
            transform.rotation = Quaternion.identity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.GameOver();
    }
    
    private void Jump()
    {
        rb.linearVelocity = Vector2.up * flapForce;
    }
}