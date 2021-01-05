using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{   
  //  public GameObject GameOver;
    private float topBound = 30;
    private float lowerBound = -1;


    // Start is called before the first frame update
    void Start()
    {
        //GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If a penguin goes past the players view in  the game, remove that penguin
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        else if (transform.position.z < lowerBound)
        {   
            Destroy(gameObject);
            KeepLives.lives -= 1;
        }
    }
}
