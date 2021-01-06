using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //function for the PlayAgain Button
    public void PlayAgain()
    {
        //restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //function for the Back Button
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
