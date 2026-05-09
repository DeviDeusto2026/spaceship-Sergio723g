using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 10f;
    public float mouseSensitivity = 2f;
    public float xLimit = 80f;
    public float yLimit = 80f;
    public float zLimit = 80f;

    private Rigidbody rb;
    private float pitch = 0f; // arriba/abajo
    private float yaw = 0f;   // izquierda/derecha

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // oculta el cursor
    }

    void FixedUpdate()
    {
        // Mouse controla dirección
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -89f, 89f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);

        // WASD mueve en la dirección que mira la nave
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * h + transform.forward * v) * speed * Time.deltaTime;
        Vector3 newPos = rb.position + move;

        newPos.x = Mathf.Clamp(newPos.x, -xLimit, xLimit);
        newPos.y = Mathf.Clamp(newPos.y, -yLimit, yLimit);
        newPos.z = Mathf.Clamp(newPos.z, -zLimit, zLimit);

        rb.MovePosition(newPos);
    }
}