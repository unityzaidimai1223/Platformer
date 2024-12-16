using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float detectionRadius = 5f; // Radius within which the enemy detects the player
    public float moveSpeed = 2f;       // Speed at which the enemy moves towards the player

    private Transform playerTransform;
    private bool isChasing = false;

    void Update()
    {
        // Check if the player exists in the scene
        if (playerTransform == null)
        {
            // Try to find the player by tag
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }

        if (playerTransform != null)
        {
            // Calculate distance between enemy and player
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer <= detectionRadius)
            {
                // Start chasing the player
                isChasing = true;
            }
            else
            {
                // Stop chasing if the player is outside the radius
                isChasing = false;
            }

            // Move towards the player if chasing
            if (isChasing)
            {
                MoveTowardsPlayer();
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        // Move the enemy towards the player's position
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the enemy collides with the player
        if (other.CompareTag("Player"))
        {
            // Destroy the enemy
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the detection radius in the Scene view for debugging
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
