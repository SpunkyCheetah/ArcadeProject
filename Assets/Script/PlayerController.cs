using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // int for movement speed
    private float horizontalInput; // float for horizontal input
    private float verticalInput; // float for vertical inpute
    public GameObject projectile; // the projetcile prefab
    public GameObject projectileSpawn; // spawn location for projectiles
    public GameManager gameManager; // the game manager
    public GameObject deathParticles; // the particles that play on death
    public AudioSource audioSource; // the audio source
    public AudioClip fireWoosh; // sound effect for launching a projectile

    // Start is called before the first frame update
    void Start()
    {
        // Set up the componenrs
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set horizontal and vertical inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Set forward to be properly forward
        Vector3 direction = new Vector3 (horizontalInput, 0, verticalInput);
        if(direction.magnitude > 0)
        {
            transform.forward = direction;
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }

        // Shoot projectile when the correct button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
            audioSource.PlayOneShot(fireWoosh);
        }


        // if the player goes off the edge of the screen they reapears on the other side
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

    public void Die()
    {
        Instantiate(deathParticles, transform.position, transform.rotation);
        gameManager.isPlayerDead = true;
        gameManager.StartCoroutine(gameManager.DeathScreen());
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the player comes into contact with an enemy they die and inform the game manager of it
        if (collision.gameObject.CompareTag("Enemy") && !gameManager.isPlayerDead)
        {
            Die();
        }
    }
}
