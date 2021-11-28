using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void START()
    {
       SceneManager.LoadScene("Matthew October 31");
    }
    public void EXIT()
    {
       Application.Quit();
    }
}
