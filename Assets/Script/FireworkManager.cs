using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkManager : MonoBehaviour
{
    public GameObject[] fireworks; // list of fireworks
    public float spawnRange; // x range for spawning
    private float waveSize; // number of fireworks per wave
    private AudioSource audioSource; // the audio source
    public AudioClip buttonAudio; // sound effect for button presses

    // Start is called before the first frame update
    void Start()
    {
        // Attach audio source component
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Start a wave of fireworks when the extra button is pressed
        if (Input.GetButtonDown("Extra"))
        {
            StartFireworkWave();
        }
    }

    // Creates a wave of fireworks
    IEnumerator FireWorkWave()
    {
        // Decides how many fireworks to create
        waveSize = Random.Range(3, 5);

        // Creates fireworks until enough have been created
        for (int i = 0; i < waveSize; i++)
        {
            // Creates a firework at a random x position
            Instantiate(RandomFirework(), RandomPosition(), fireworks[0].transform.rotation);

            // Waits a moment
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
        }
    }

    // The method for buttons to trigger a wave of fireworks
    public void StartFireworkWave()
    {
        audioSource.PlayOneShot(buttonAudio);
        StartCoroutine(FireWorkWave());
    }

    // Returns a vector3 ith a random X value
    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-spawnRange, spawnRange), transform.position.y, 600);
    }

    // Returns a random FameObject from the fireworks  list
    private GameObject RandomFirework()
    {
        return fireworks[(Random.Range(0, fireworks.Length))];
    }
}
