using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    public GameObject Rel;
    // Start is called before the first frame update
    public void Reload()
    {
        Rel.active = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
