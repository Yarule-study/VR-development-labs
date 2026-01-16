using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private int health = 100;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            TakeDamage(10);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Здоров'я: " + health + "/100");

        if (health <= 0)
        {
            Debug.Log("ТАНК ЗНИЩЕНО!");
            Destroy(gameObject);
        }
    }
}