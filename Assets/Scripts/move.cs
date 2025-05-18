using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private float speed = 5.5f;
    [SerializeField] private float rotationSpeed = 250f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.Self);

        // Rotación con el mouse
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Limites del mapa
        if (transform.position.x < -28f)
        {
            transform.position = new Vector3(-27.7f, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -12.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -12f);
        }
        if (transform.position.z > 14.3f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 14);
        }
        if (transform.position.x > 29f)
        {
            transform.position = new Vector3(28.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.y < 1f)
        {
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}