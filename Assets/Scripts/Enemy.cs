using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public int health = 3;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (player != null)
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime);
    }
    public void TakeDamage(int dmg)
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHealth>()?.Die();
            Destroy(gameObject);
        }
    }

}