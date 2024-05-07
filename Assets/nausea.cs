using UnityEngine;

public class NauseaEffect : MonoBehaviour
{
    public Transform enemy; // Reference to the enemy GameObject
    public float nauseaDistance = 10f; // Distance threshold for applying the effect
    public float nauseaIntensity = 0.5f; // Intensity of the effect

    public GameObject cameraView; // Reference to the child GameObject representing the camera view

    void Start()
    {
        // Ensure the cameraView variable is assigned correctly
        if (cameraView == null)
        {
            Debug.LogError("Please assign the camera view GameObject in the inspector!");
            enabled = false; // Disable the script if the camera view is not assigned
            return;
        }
    }

    void Update()
    {
        // Check if the player is within the distance threshold of the enemy
        if (Vector3.Distance(transform.position, enemy.position) < nauseaDistance)
        {
            // Apply the nausea effect to the camera view
            ApplyNauseaEffect();
        }
        else
        {
            // Reset the camera view if the player is not near the enemy
            ResetCameraView();
        }
    }

    void ApplyNauseaEffect()
    {
        // Rotate the camera view randomly to simulate dizziness
        float rotationX = Random.Range(-nauseaIntensity, nauseaIntensity);
        float rotationY = Random.Range(-nauseaIntensity, nauseaIntensity);
        float rotationZ = Random.Range(-nauseaIntensity, nauseaIntensity);
        cameraView.transform.Rotate(rotationX, rotationY, rotationZ);
    }

    void ResetCameraView()
    {
        // Reset the camera view rotation to its original state
        cameraView.transform.localRotation = Quaternion.identity;
    }
}