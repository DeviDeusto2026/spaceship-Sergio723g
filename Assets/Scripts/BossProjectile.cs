using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = 8f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if (player != null)
            transform.position = Vector3.MoveTowards(
                transform.position, player.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.position) < 0.5f)
        {
            player.GetComponent<PlayerHealth>()?.Die();
            Destroy(gameObject);
        }
    }
}