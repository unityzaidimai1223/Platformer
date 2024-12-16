using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public Vector3 direction;  // Direction of the bullet
    public float speed = 10f;  // Speed of the bullet
    public float lifetime = 2f; // How long the bullet exists before being destroyed

    void Start()
    {
        Destroy(gameObject, lifetime); // Automatically destroy bullet after its lifetime
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime; // Move the bullet
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Check if the collided object is tagged as 'Enemy'
        {
            Destroy(other.gameObject); // Destroy the enemy
            Destroy(gameObject);       // Destroy the bullet
        }
    }
}
