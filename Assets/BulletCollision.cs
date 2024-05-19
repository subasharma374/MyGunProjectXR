using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public Transform bullseyeCenter; // Reference to the center of the bullseye

    private void Start()
    {
        if (bullseyeCenter == null)
        {
            Debug.LogError("Bullseye center is not assigned!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Target"))
        {
            // Get the point of collision
            ContactPoint contact = collision.contacts[0];
            Vector3 hitPoint = contact.point;

            // Calculate the distance to the center of the bullseye
            float distanceToBullseye = Vector3.Distance(hitPoint, bullseyeCenter.position);

            // Display or log the distance
            Debug.Log("Distance to bullseye: " + distanceToBullseye);

            // Optionally, destroy the bullet upon collision
            //Destroy(gameObject);
        }
        else
        {
            Debug.Log("Collided with a non-target object.");
        }
    }
}
