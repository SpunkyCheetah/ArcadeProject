using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkController : MonoBehaviour
{
    public float moveSpeed; // speed at which firework will launch upwards
    public float duration; // time before firework will explode
    public ParticleSystem trail; // the smoke trail for the firework
    public ParticleSystem explosion; // the xplosion of the firework
    private bool isMoving = true; // bool to track if the firework is moving
    private AudioSource audioSource; // the audio source
    public AudioClip fireworkAudio; // sound effect fireworks play on exploding

    // Start is called before the first frame update
    void Start()
    {
        // Attach audio source component
        audioSource = GetComponent<AudioSource>();

        // Set a random speed and an amount of time to wait before exploding
        moveSpeed = Random.Range(400, 600);
        duration = Random.Range(0.5f, 1.5f);

        // Wait and then explode
        StartCoroutine(WaitThenExplode());
    }

    // Wait and then explode
    IEnumerator WaitThenExplode()
    {
        // Make sure the trail is on and the firework is not exploding yet
        trail.Play();
        explosion.Stop();

        // Wait a few seconds to allow firework to get up high
        yield return new WaitForSeconds(duration);

        // Play explosion sound
        audioSource.PlayOneShot(fireworkAudio);

        // Tell firework to stop moving
        isMoving = false;
        
        // Turn off the trail and explode
        trail.Stop();
        explosion.Play();

        // Destroy after 2 seconds
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        // If it is supposed to be moving, move upwards at a constant rate
        if (isMoving)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }
}
