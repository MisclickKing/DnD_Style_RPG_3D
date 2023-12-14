using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSolution : MonoBehaviour
{
    [SerializeField] int x = 1920;
    [SerializeField] int y = 1080;

    // Start is called before the first frame update
    void Start()
    {
        // Switch to 1080 x 1920 full-screen
        Screen.SetResolution(x, y, true);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
