using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidScript : MonoBehaviour
{
    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    public int asteroidSize; // 3- big, 2-medium, 1 = small
    public GameObject asteroidMedium;
    public GameObject asteroidSmall;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);

        asteroidSize = 3; //big size
    }

    // Update is called once per frame
    void Update()

    {
        Vector2 newPos = transform.position;
        if (transform.position.y > screenTop)
        {
            newPos.y = screenBottom;
        }

        if (transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }

        if (transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }

        if (transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }

        transform.position = newPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);

            if (asteroidSize == 3)
            {
                GameObject asteroid1 = Instantiate(asteroidMedium, transform.position, transform.rotation);
                GameObject asteroid2 = Instantiate(asteroidMedium, transform.position, transform.rotation);
                asteroid1.GetComponent<AsteroidScript>().asteroidSize = 2;
                asteroid2.GetComponent<AsteroidScript>().asteroidSize = 2;
                
                Destroy(gameObject);
            }

            else if (asteroidSize == 2)
            {
            }

            else if (asteroidSize == 1)
            {
            }
        }
    }
}