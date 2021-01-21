using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 15f;
    private float xRange = 13f;

    private bool canMove = true;
    public GameObject GameOverPanel;

    private float myTime = 0.0f;
    float nextTimeToFire;

    public GameObject projectilePrefab;

    [Header("Reload")]

    private int maxAmmo = 5;
    private int currentAmmo;
    private float reloadTime = 3f;
    private bool isReloading = false;

    AudioSource makesnowball;

    public Text snowballText;       //link to the snowball ammo text on the screen


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;

        snowballText.text = currentAmmo.ToString();

        makesnowball = GetComponent<AudioSource>();

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

        if (GameOverPanel.activeSelf)
        {
            canMove = false;

            horizontalInput = 0;

            currentAmmo = 0;
            maxAmmo = 0;

            snowballText.text = currentAmmo.ToString();

            makesnowball.Stop();
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
            if (!makesnowball.isPlaying)
            makesnowball.Play();

            return;
        }
        else
        {
            makesnowball.Stop();
        }

        if (currentAmmo <= 0)
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

        //update ammo text on screen
        snowballText.text = currentAmmo.ToString();
    }

    //reload
    IEnumerator Reload()
    {
        isReloading = true;

        //Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isReloading = false;

        //update ammo text on screen
        snowballText.text = currentAmmo.ToString();
    }

}
