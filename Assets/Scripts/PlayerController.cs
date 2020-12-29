using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 5.0f;
    public float xRange = 10.0f;

    public GameObject porjectilePrefab;

    float nextTimeToFire;

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
        

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if(isReloading){
            return;
        }

        if (currentAmmo <= 0){
           StartCoroutine(Reload());
           return;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextTimeToFire)
        { Shoot();
        }
       
       

    }

    void Shoot(){

         
            Instantiate(porjectilePrefab, transform.position, porjectilePrefab.transform.rotation);
            nextTimeToFire = Time.time + .3f;
            currentAmmo--;
        

    }

    IEnumerator Reload(){

            isReloading = true;

            Debug.Log("Reloading...");
            
            yield return new WaitForSeconds(reloadTime);

            currentAmmo = maxAmmo;

            isReloading = false;
    }
}
