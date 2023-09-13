using UnityEngine;
public class KeyboardController : MonoBehaviour
{
    public float speed = 3.0f;
    public Transform cameraTransform;
    private Rigidbody rb;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection.Normalize();

        if (cameraTransform != null)
        {
            Vector3 cameraForward = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized;
            Vector3 cameraRight = new Vector3(cameraTransform.right.x, 0, cameraTransform.right.z).normalized;
            moveDirection = cameraForward * moveDirection.z + cameraRight * moveDirection.x;
        }

        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
