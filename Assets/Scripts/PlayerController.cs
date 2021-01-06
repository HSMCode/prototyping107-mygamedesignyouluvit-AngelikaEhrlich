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

    public GameObject GameOverPanel;
    private bool canMove = true;

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

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //determines whether the player is allowed to move or not
        if (KeepLives.lives > 0)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }

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

        if (GameOverPanel.activeSelf)
        {
            //Debug.Log("gameoverpanel..");

            canMove = false;

            horizontalInput = 0;

            currentAmmo = 0;

            maxAmmo = 0;
        }
    }

    void FixedUpdate()
    {
        //movement (but only let the player move, if he can / has one or more lives
        if (canMove)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }

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
