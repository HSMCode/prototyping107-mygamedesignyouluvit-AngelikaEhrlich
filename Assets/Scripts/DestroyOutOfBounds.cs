using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -1;

    // Start is called before the first frame update
    void Start()
    {

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
            //check to see if we have any lives left
            if (KeepLives.lives != 0)
            {
                Destroy(gameObject);
                KeepLives.lives -= 1;
            }
            else
            {
                Destroy(gameObject);
                KeepLives.lives = 0;
            }
        }
    }

}
