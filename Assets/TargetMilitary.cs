using UnityEngine;


public class TargetMilitary : MonoBehaviour
{
    [Tooltip("The precise bullseye position")]
    public GameObject bullseye;

   

    private Vector3 bullseyePosition;
    


    void Start()
    {
        // Ensure the bullseye GameObject is assigned
        if (bullseye != null)
        {
            print("bullseye found!!!!!!!!!!!!!!!!!!!!");
            bullseyePosition = bullseye.transform.position;
        }
        else
        {
            Debug.LogError("Bullseye GameObject is not assigned.");
            // Default to the center of the target if bullseye is not assigned
            bullseyePosition = transform.position;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision happened with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Bullet hit detected!");
            Vector3 hitPosition = collision.contacts[0].point;
            CalculateDistanceFromBullseye(hitPosition);

        }
        else
        {
            Debug.Log("The object that hit the target is not tagged as 'Bullet'. Its tag is: " + collision.gameObject.tag);
        }
    }

    void CalculateDistanceFromBullseye(Vector3 hitPosition)
    {
        float distance = Vector3.Distance(hitPosition, bullseyePosition);
        Debug.Log("Distance from bullseye: " +  (distance-0.21));

        // Provide feedback to the user
        ProvideFeedback(distance, hitPosition);
    }

    void ProvideFeedback(float distance, Vector3 hitPosition)
    {
        // You can implement visual feedback here
        // For example, drawing a line from the bullseye to the hit position
        Debug.DrawLine(bullseyePosition, hitPosition, Color.red, 2.0f);

        // Or, displaying the distance on the screen
        // You can use UI elements like Text to display the distance
    }

}
