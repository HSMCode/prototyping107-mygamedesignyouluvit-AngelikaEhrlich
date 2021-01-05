using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -1;

   // public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("player");
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

            //check to see if we have any lives left
            if (KeepLives.lives < 1)
            {
                //out of lives
                GameOver ();
            }
        }
    }

    //gameOver function
    void GameOver()
    {
        Debug.Log("out of lives");

        //make player disappear and be disabled
        //player.SetActive(false);

        //set lives score to 0
        KeepLives.lives = 0;
    }

}
