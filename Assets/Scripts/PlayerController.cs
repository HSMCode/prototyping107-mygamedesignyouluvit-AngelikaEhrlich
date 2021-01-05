using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 5.0f;
    public float xRange = 10.0f;

    float nextTimeToFire;

    public int score;   //players score

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //player map boundaries
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        //shoot projectile aka snowball
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextTimeToFire)
        { 
            Shoot();
        }
       
    }

    void Shoot()
    {  
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            nextTimeToFire = Time.time + .2f;
    }

    //ScorePoints will be called from the DetectCollisions Script when a collision occures
    //between projectile and enemy
    void ScorePoints()
    {
        //add points to the score
        score += 1;
    }
}
