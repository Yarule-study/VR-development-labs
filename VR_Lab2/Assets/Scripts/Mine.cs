using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int damage = 30;
    [SerializeField] private GameObject explosionPrefab; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (explosionPrefab != null)
            {
                GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
                Destroy(explosion, 2f);
            }

            CollisionHandler handler = other.GetComponent<CollisionHandler>();
            if (handler != null)
            {
                handler.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}