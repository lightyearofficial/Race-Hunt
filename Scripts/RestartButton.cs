using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
       SceneManager.LoadScene("Matthew October 31");
    }
    public void MainMenu()
    {
       SceneManager.LoadScene("MainMenu");
    }
}
