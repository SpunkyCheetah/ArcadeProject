using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float moveSpeed; // float for movement speed

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-350, 225), transform.position.y, Random.Range(-75, 75));
        moveSpeed = Random.Range(10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        // Move forward at a constant rate
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (transform.position.x > 250)
        {
            transform.position = new Vector3(-250, transform.position.y, Random.Range(-75, 75));
            moveSpeed = Random.Range(10, 20);
        }
    }
}
