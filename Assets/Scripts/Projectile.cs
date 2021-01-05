using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 45.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move projectile
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Enemy"))
        {
            //remove this object from the game
            Destroy(this.gameObject);
            //but also remove the other object from the game
            Destroy(other.gameObject);
            //score points
            KeepScore.score += 5;
        }
    }
}
