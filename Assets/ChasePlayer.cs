using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour
{
    public GameObject Target;
    public Rigidbody RB;
    public float Speed = 3;
    public AudioSource srcMusic;
    public AudioSource srcScreams;
    public AudioSource srcJS;
    public AudioClip srcM;
    public AudioClip srcS;
    public AudioClip srcJ;
    


    void Start()
    {
        srcMusic.clip = srcM;
        srcScreams.clip = srcS;
        srcJS.clip = srcJ;
        StartCoroutine(ChaseRoutine());

    }

    IEnumerator ChaseRoutine()
    {
        while (true) // Repeat forever

        {
            
            // Teleport 5000 units away from the player and set y position to 0
            srcScreams.Stop();
            srcMusic.Stop();
            srcJS.Stop();
            Vector3 teleportAwayPosition = Target.transform.position + Random.onUnitSphere * 500f;
            teleportAwayPosition.y = 0f; // Set y position to 0
            transform.position = teleportAwayPosition;

            // Wait for 3 seconds
            yield return new WaitForSeconds(30f);

            // Teleport 3 units in front of the player
            Vector3 directionToPlayer = Target.transform.position - transform.position;
            directionToPlayer.y = 0f; // Ignore height difference
            Vector3 teleportPosition = Target.transform.position + directionToPlayer.normalized * 3f;
            teleportPosition.y = transform.position.y; // Ensure same y position
            transform.position = teleportPosition;
            srcJS.Play();

            // Face towards the player
            transform.LookAt(Target.transform);

            // Stand still for 2 seconds
            yield return new WaitForSeconds(2f);

            // Chase the player for 3 seconds
            float chaseTimer = 0f;
            srcMusic.Play();
            srcScreams.Play();
            while (chaseTimer < 30f)
            {
                transform.LookAt(Target.transform);
                RB.velocity = transform.forward * Speed;
                chaseTimer += Time.deltaTime;
                yield return null;
            }

            // Reset velocity
            RB.velocity = Vector3.zero;
        }
    }
}