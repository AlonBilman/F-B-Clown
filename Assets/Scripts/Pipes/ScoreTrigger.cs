using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool hasScored = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if collider belongs to Bird
        if (!hasScored && other.GetComponent<Bird>() != null)
        {
            hasScored = true;
            ScoreManager.Instance.AddPoint();
        }
    }

    private void OnEnable()
    {
        // Reset when pipe is reused from pool
        hasScored = false;
    }
}
