using UnityEngine;

public class PowerBox : MonoBehaviour
{
    public AudioSource srcPower;
    public AudioClip srcP;
    bool isActivated = false; // Flag to track if the box has been activated
    public FirstPersonController playerController; // Reference to the FirstPersonController script
    public int pointsToAdd = 1; // Points to add when the box is activated

    private void Start()
    {
        srcPower.clip = srcP;
    }

    void OnMouseDown()
    {
        // Check if the box has not been activated yet
        if (!isActivated)
        {
            // Add points to the player
            playerController.AddPoints(pointsToAdd);

            // Set the box as activated
            isActivated = true;
            Debug.Log("activated");
            srcPower.Play();
        }
    }
}