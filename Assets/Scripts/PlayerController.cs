using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float speed = 10.0f;
    public float xRange = 10.0f;
    public GameObject projectilePrefab;
    private int lives = 3;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Time.deltaTime * Vector3.right * horizontalInput * speed);
        transform.Translate(Time.deltaTime * Vector3.forward * verticalInput * speed);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Food_Pizza_01(Clone)")
        {
            lives--;
            Debug.Log("Lives: " + lives);
            if (lives < 1)
            {
                Debug.Log("Game Over");
            }
        }
    }

    public void addScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}
