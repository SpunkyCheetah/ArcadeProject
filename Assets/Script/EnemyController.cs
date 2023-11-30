using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        moveSpeed = Random.Range(10, 30);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
