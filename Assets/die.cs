using UnityEngine;
using UnityEngine.SceneManagement;

public class DieOnContact : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is tagged as "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Load Scene 2
            SceneManager.LoadScene(2);
        }
    }
}