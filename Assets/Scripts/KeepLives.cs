﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepLives : MonoBehaviour
{
    public static int lives = 5;

    public GameObject GameOverPanel;        //link to the game over panel in the scene

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);

        lives = 5;   
}

    // Update is called once per frame
    void Update()
    {
        //check to see if we have any lives left
        if (KeepLives.lives <= 0)
        {
            //out of lives
            GameOver();
        }
    }

    //lives box
    private void OnGUI()
    {
        //set font size
        GUI.skin.box.fontSize = 45;

        //set font color
        GUI.contentColor = Color.red;

        //set text alignment to the left
        GUI.skin.box.alignment = TextAnchor.UpperLeft;

        //set box color
        GUI.backgroundColor = new Color(0, 0, 0, 0);

        //set box size, position, and text
        GUI.Box(new Rect(40, 110, 250, 60), "Lives: " + lives.ToString());
    }


    //gameOver function
    void GameOver()
    {
        //set lives score to 0
        KeepLives.lives = 0;

        //turn on the game over panel
        GameOverPanel.SetActive(true);
    }

}
