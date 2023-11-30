using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnDelay;
    public GameObject enemy;
    private Vector3 location;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        /*
         * if (Random.Range(1,0) == 0)
        {
            if (Random.Range(1, 0) == 0)
            {
                location = new Vector3(Random.Range(120, -120), 0, 75);
            }
            else
            {
                location = new Vector3(Random.Range(120, -120), 0, -75);
            }
        }
        else
        {
            if (Random.Range(1, 0) == 0)
            {
                location = new Vector3(120, 0, Random.Range(75, -75));
            }
            else
            {
                location = new Vector3(-120, 0, Random.Range(75, -75));
            }
        }
        */

        location = new Vector3(Random.Range(120, -120), 0, Random.Range(75, -75));

        transform.Rotate(Vector3.up, Random.Range(0, 180));
        Instantiate(enemy, location, transform.rotation);
    }
}
