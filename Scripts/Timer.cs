using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float delay = 1f;
    public float timeLeft = 1f;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft % 60 >= 10) {
            text.text = "" + (int)(timeLeft / 60) + ":" + (int)(timeLeft % 60);
        } else {
            text.text = "" + (int)(timeLeft / 60) + ":0" + (int)(timeLeft % 60);
        }
        if(timeLeft <= 0)
        {
           SceneManager.LoadScene("LoseScreen");
        }
    }
}
