using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private Animator m_anim;
    private static readonly int Move = Animator.StringToHash("Walk");

    private void Start()
    {
        m_anim = GetComponentInChildren<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
    }
}
