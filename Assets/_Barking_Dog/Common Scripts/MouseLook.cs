using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 2f;
    private float platform = 0f;
    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit))
        {
            platform = hit.point.y;
        }

        // move
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Tạo vector di chuyển theo không gian cục bộ của camera
        Vector3 movement = transform.right * horizontal + transform.forward * vertical;
        movement *= speed * Time.deltaTime;

        controller.Move(movement);

        // mouse rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.World);
        transform.Rotate(Vector3.left, mouseY * rotationSpeed, Space.Self);

        transform.position = new Vector3(transform.position.x, platform + 1.75f, transform.position.z);
    }
}
