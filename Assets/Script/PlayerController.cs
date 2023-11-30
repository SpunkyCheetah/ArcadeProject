using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private float horizontalInput;
    private float verticalInput;
    public GameObject projectile;
    public GameObject projectileSpawn;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3 (horizontalInput, 0, verticalInput);
        if(direction.magnitude > 0)
        {
            transform.forward = direction;
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }

        /*transform.Translate(Vector3.forward * moveSpeed * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);*/

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        }



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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.isPlayerDead = true;
            Destroy(gameObject);
        }
    }
}
