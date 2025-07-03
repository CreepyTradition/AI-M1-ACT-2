using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // The car's transform
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset from the car
    public float smoothSpeed = 0.125f;  // Smoothing factor

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position based on offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between current and desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera position
        transform.position = smoothedPosition;

        // Optionally look at the target
        transform.LookAt(target);
    }
}
