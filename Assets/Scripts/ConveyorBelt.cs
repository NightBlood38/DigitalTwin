using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 1.5f;
    public bool isRunning = true;

    void OnCollisionStay(Collision collision)
    {
        if (isRunning && collision.rigidbody != null)
        {
            Vector3 movement = transform.right * speed;
            movement.y = collision.rigidbody.linearVelocity.y;
            collision.rigidbody.linearVelocity = movement;
        }
    }
}