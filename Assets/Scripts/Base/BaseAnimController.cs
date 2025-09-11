using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BaseAnimController : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.enabled = GameManager.Instance.IsGameActive();
    }
}
