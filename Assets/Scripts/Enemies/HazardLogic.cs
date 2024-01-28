using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Transform respawnPoint;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Die();
        }
    }
    
    private void Die()
    {
        transform.position = respawnPoint.position;
    }
}