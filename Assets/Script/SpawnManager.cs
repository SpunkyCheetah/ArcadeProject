using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnDelay; // delay between spawning enemies
    public GameObject enemy; // the enemy prefab
    private Vector3 location; // the location the enemy will spawn at
    public GameManager gameManager; // the game manager

    // Start is called before the first frame update
    void Start()
    {
        // Set up the game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Start spawning enemies indefinitely
        InvokeRepeating("SpawnEnemy", 0, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        // Choose location for new enemy to spawn
        location = new Vector3(Random.Range(120, -120), 0, Random.Range(75, -75));

        // Choose a direction for new enemy to face
        transform.Rotate(Vector3.up, Random.Range(0, 180));

        // Only spawn enemies if player is alive
        if (!gameManager.isPlayerDead)
        {
            Instantiate(enemy, location, transform.rotation);
        }
    }
}
