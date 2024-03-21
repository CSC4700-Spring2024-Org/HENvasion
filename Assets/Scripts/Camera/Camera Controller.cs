using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minVerticalAngle = -60f; // Minimum vertical rotation angle in degrees
    public float maxVerticalAngle = 60f; // Maximum vertical rotation angle in degrees

    private float rotationX; // Current vertical rotation

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX); // Rotate horizontally

        rotationX -= mouseY; // Update vertical rotation
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle); // Clamp vertical rotation

        transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0f); // Apply the new rotation
    }
}



