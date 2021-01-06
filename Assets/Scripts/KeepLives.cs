using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepLives : MonoBehaviour
{
    public static int lives = 5;

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
        GUI.Box(new Rect(1460, 10, 100, 100), lives.ToString());
    }
}
