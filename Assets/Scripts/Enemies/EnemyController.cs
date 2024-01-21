using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float moveDistance = 3.0f;

    private Vector3 startPosition;
    private bool movingLeft = true;
    private Animator animator;
    private bool enemyFacingRight = true;

    void Start()
    {
        startPosition = transform.position;
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator not found on the enemy.");
        }
    }

    void Update()
    {
        if (movingLeft)
        {
            if (enemyFacingRight) {
                Flip();
            }
            if (transform.position.x > startPosition.x - moveDistance)
            {
                MoveInDirection(-1);
            }
            else
            {
                ChangeDirection();
            }
        }
        else
        {
            if (transform.position.x < startPosition.x + moveDistance)
            {
                MoveInDirection(1);
            }
            else
            {
                ChangeDirection();
            }
        }
    }
    
    void ChangeDirection()
    {
        movingLeft = !movingLeft;
        Flip();
    }

    void Flip()
    {
        enemyFacingRight = !enemyFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void MoveInDirection(int direction)
    {
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);
    }
}
