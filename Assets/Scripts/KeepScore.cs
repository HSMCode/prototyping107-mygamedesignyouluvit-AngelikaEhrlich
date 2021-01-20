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

        //set font color
        GUI.contentColor = Color.blue * Color.white;

        //set text alignment to the left
        GUI.skin.box.alignment = TextAnchor.UpperLeft;

        //set box color
        GUI.backgroundColor = new Color(0, 0, 0, 0);

        //set box size, position, and text
        GUI.Box(new Rect(40, 40, 400, 60), "Score: " + score.ToString());
    }
}
