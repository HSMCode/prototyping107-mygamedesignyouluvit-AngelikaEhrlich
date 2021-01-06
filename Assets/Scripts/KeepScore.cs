using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeepScore : MonoBehaviour
{
   public static int score = 0;

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
        GUI.Box(new Rect(20, 10, 100, 100), score.ToString());
   }
}
