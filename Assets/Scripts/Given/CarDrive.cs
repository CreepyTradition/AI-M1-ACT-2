using UnityEngine;
using UnityStandardAssets.Utility;

[RequireComponent(typeof(Rigidbody))]
public class CarWaypointFollower : MonoBehaviour
{
    public WaypointProgressTracker tracker;
    public float speed = 1f;
    public float turnSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void FixedUpdate()
    {
        if (tracker == null || tracker.target == null)
            return;

        Vector3 targetDirection = (tracker.target.position - transform.position);
        targetDirection.y = 0f;
        Vector3 moveDirection = targetDirection.normalized;

        // Rotate smoothly toward the direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(newRotation);
        }

        // Move forward using Rigidbody
        Vector3 forwardMove = transform.forward * speed;
        rb.MovePosition(rb.position + forwardMove * Time.fixedDeltaTime);
    }
}
