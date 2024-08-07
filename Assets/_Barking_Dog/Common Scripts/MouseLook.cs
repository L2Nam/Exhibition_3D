using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 2f;
    private float platform = 0f;

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

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

        // Thực hiện Raycast để kiểm tra va chạm với tường
        if (!IsWallBlocking(movement))
        {
            transform.Translate(movement);
        }

        // mouse rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.World);
        transform.Rotate(Vector3.left, mouseY * rotationSpeed, Space.Self);

        transform.position = new Vector3(transform.position.x, platform + 1.75f, transform.position.z);
    }

    bool IsWallBlocking(Vector3 movement)
    {
        Ray ray = new Ray(transform.position, movement.normalized);
        RaycastHit hit;

        // Kiểm tra va chạm với tường
        if (Physics.Raycast(ray, out hit, movement.magnitude))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return true; // Nếu va chạm với tường và có tag "Wall", không di chuyển
            }
        }

        return false; // Nếu không có va chạm hoặc không có tag "Wall", cho phép di chuyển
    }
}
