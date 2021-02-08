using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject Play;
    public void Stop()
    {
        Play.active = enabled;
        Time.timeScale = 0;
    }
}
