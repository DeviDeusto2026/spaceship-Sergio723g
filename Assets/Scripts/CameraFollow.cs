using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float height = 3f;
    public float smoothSpeed = 8f;

    void LateUpdate()
    {
        // Posición detrás de la nave según su rotación
        Vector3 desiredPos = target.position
                           - target.forward * distance
                           + Vector3.up * height;

        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.LookAt(target.position + target.forward * 3f);
    }
}