using UnityEngine;

public class ShipShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;
    private float nextFire = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        }
    }
}