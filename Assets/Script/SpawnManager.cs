using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnDelay; // delay between spawning enemies
    public GameObject enemy; // the enemy prefab
    private Vector3 location; // the location the enemy will spawn at
    private GameManager gameManager; // the game manager
    public bool isSpawning = true; // are enemies spawning right now?
    public GameObject player; // the Player game object
    public float safetyRange; // the range around the player that enemies cannot spawn in

    // Start is called before the first frame update
    void Start()
    {
        // Set up the game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Start spawning enemies indefinitely
        StartCoroutine(EnemySpawnLoop());
    }

    // Spawn enemies in an ongoing loop
    IEnumerator EnemySpawnLoop()
    {
        while (isSpawning)
        {
            SpawnEnemy();

            // Delay between spawns for a length determined by vurrent difficulty levels
            spawnDelay = 3 / gameManager.dificultyModifier;
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    // Set up and spawn an enemy
    void SpawnEnemy()
    {
        // Choose location for new enemy to spawn
        location = RandomLocation();

        // Make sure enemies do not spawn on top of the player
        while ((location - player.transform.position).magnitude < safetyRange)
        {
            location = RandomLocation();
        }

        // Choose a direction for new enemy to face
        transform.Rotate(Vector3.up, Random.Range(0, 180));

        // Only spawn enemies if player is alive
        if (!gameManager.isPlayerDead)
        {
            Instantiate(enemy, location, transform.rotation);
        }
    }

    // Returns a vector for a random position
    Vector3 RandomLocation()
    {
        return new Vector3(Random.Range(120, -120), 0, Random.Range(75, -75));
    }
}
