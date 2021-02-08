using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public GameObject Play;
    // Start is called before the first frame update
    public void PlayG()
    {
        Play.active = false;
        Time.timeScale = 1;
    }
}
