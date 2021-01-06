using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 5.0f;
    public float xRange = 10.0f;

    private float myTime = 0.0f;
    float nextTimeToFire;

    public GameObject projectilePrefab;


    [Header("Reload")]

    public int maxAmmo = 2;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    AudioSource snowsteps;
    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;

        snowsteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //determines when the player is moving
        if (horizontalInput != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        //if the player is moving, play snowsteps sound
        if (isMoving)
        {
            if (!snowsteps.isPlaying)
                snowsteps.Play();
        }
        else
        {
            snowsteps.Stop();
        }
    }

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

        //reloading
        if(isReloading)
        {
            return;
        }

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        //shoot projectile aka snowball
        if (Input.GetKeyDown(KeyCode.Space) && myTime >= nextTimeToFire)
        {
            Shoot();
        }

    }

    //shoot
    void Shoot()
    {
        nextTimeToFire = nextTimeToFire - myTime;
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        currentAmmo--;
    }

    //reload
    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isReloading = false;

    }

}
