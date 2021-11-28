using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Camera2;
    public GameObject Camera3;

    public Rigidbody rb;
    public Image actualSpeedIcon;

    //Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            MainCamera.SetActive(true);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            MainCamera.SetActive(false);
            Camera2.SetActive(true);
            Camera3.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            MainCamera.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(true);
        }

        actualSpeedIcon.fillAmount = rb.velocity.magnitude / 35f;


    }
}
