using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnDelay;
    public GameObject enemy;
    private Vector3 location;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnEnemy", 0, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {

        location = new Vector3(Random.Range(120, -120), 0, Random.Range(75, -75));

        transform.Rotate(Vector3.up, Random.Range(0, 180));
        if (!gameManager.isPlayerDead)
        {
            Instantiate(enemy, location, transform.rotation);
        }
    }
}
