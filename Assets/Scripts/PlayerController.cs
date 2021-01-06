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



    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
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

    void Shoot()
    {
        nextTimeToFire = nextTimeToFire - myTime;
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        currentAmmo--;
    }

    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isReloading = false;

    }

}
