using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public float hitRadius = 3f;
    public GameObject hitEffect;
    private Vector3 direction;

    void Start()
    {
        direction = transform.forward;
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        Collider[] hits = Physics.OverlapSphere(transform.position, hitRadius);
        foreach (Collider col in hits)
        {
            // Detecta enemigo normal
            Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(3);
                Destroy(gameObject);
                return;
            }

            // Detecta boss
            Boss boss = col.GetComponent<Boss>();
            if (boss != null)
            {
                boss.TakeDamage(1);
                Destroy(gameObject);
                return;
            }
        }
    }
}