using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeepScore : MonoBehaviour
{
   public static int score = 0;
   
   public Font font;            //link to the font

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnGUI()
   {
        //set font
        GUI.skin.font = font;

        //set font size
        GUI.skin.box.fontSize = 45;

        //set box color
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        //GUI.backgroundColor = Color.gray;

        //set font color
        GUI.contentColor = Color.blue * Color.gray;

        //set box size, position, and text
        GUI.Box(new Rect(30, 30, 400, 60), "Score: " + score.ToString());
   }
}
