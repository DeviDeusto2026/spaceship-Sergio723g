using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 15;
    public float speed = 5f;
    public float sinAmplitude = 4f;
    public float sinFrequency = 2f;
    public GameObject projectilePrefab;
    public GameObject minionPrefab;
    public float fireRate = 1.5f;

    private Transform player;
    private float nextFire;
    private float time;
    private EnemySpawner spawner;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spawner = FindObjectOfType<EnemySpawner>();
        if (spawner != null) spawner.enabled = false;
    }

    void Update()
    {
        time += Time.deltaTime;

        // Movimiento sinusoidal
        Vector3 target = player.position;
        target.y = Mathf.Sin(time * sinFrequency) * sinAmplitude;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Disparar al jugador
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (projectilePrefab != null)
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        // Spawna minion al recibir daño
        if (minionPrefab != null)
            Instantiate(minionPrefab, transform.position, Quaternion.identity);
        if (health <= 0) Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
            col.GetComponent<PlayerHealth>()?.Die();
    }
}