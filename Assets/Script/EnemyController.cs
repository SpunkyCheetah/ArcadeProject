using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed; // movement speed variable
    public int scoreValue; // how many point destroying this enemy is worth
    public float respawnSpace = 20; // the range around 0,0,0 that the enemy will avoid during respawn
    private GameManager gameManager; // the game manager
    public GameObject deathParticles; // the particles that play on death
    private AudioSource audioSource; // the audio source
    public AudioClip deathAudio; // sound effect for the enemy being destroyed

    public GameObject model;

    // Start is called before the first frame update
    void Start()
    {
        // Set up the components
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();

        // Set a random speed for the enemy
        moveSpeed = Random.Range(10, 20) * (1 + gameManager.dificultyModifier / 10);
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy moves forward at a constant rate
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Enemy avoids the space around spawn while the player is respawning
        if (gameManager.isPlayerDead && transform.position.x < respawnSpace && transform.position.x > -respawnSpace && transform.position.z < respawnSpace && transform.position.z > -respawnSpace)
        {
            transform.Translate(Vector3.forward * -(respawnSpace * 1.5f));
            transform.Rotate(Vector3.up, 180);
        }

        // if an enemy goes off the edge of the screen it reapears on the other side
        if (transform.position.x > 110)
        {
            transform.position = new Vector3(-100, 0, transform.position.y);
        }
        if (transform.position.x < -110)
        {
            transform.position = new Vector3(100, 0, transform.position.y);
        }
        if (transform.position.z > 70)
        {
            transform.position = new Vector3(transform.position.x, 0, -60);
        }
        if (transform.position.z < -70)
        {
            transform.position = new Vector3(transform.position.x, 0, 60);
        }
    }

    // Enemy checks for collisions
    private void OnCollisionEnter(Collision collision)
    {
        // When hit by a projectile the enemy is destroyed
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Plays death nsound effect
            audioSource.PlayOneShot(deathAudio);

            // Displays death particles
            Instantiate(deathParticles, transform.position, transform.rotation);

            // Add to score
            gameManager.UpdateScore(scoreValue);

            // Disable enemy without destroying for a few seconds while audio plays
            Destroy(model);
            Collider[] colliders = GetComponents<Collider>();
            foreach(Collider collider in colliders)
            {
                collider.enabled = false;
            }

            // Destroy the game object
            Destroy(gameObject, 2);
        }
    }
}
