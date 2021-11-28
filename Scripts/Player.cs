using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkingSpeed = 5f;
    public float currentSpeed = 5f;
    public float sprintingSpeed = 10f;
    public float lookHorizontal = 0;
    public float lookVertical = 0;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            currentSpeed = sprintingSpeed;
        }

        lookHorizontal += Input.GetAxis("Mouse X");
        lookVertical += Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(-lookVertical, lookHorizontal, 0f);
    }

    void OnCollisionStay(Collision coll) {
        if(coll.gameObject.CompareTag("Ground")) {
           isGrounded = true;
        }
    }

    void OnCollisionExit(Collision coll) {
        if(coll.gameObject.CompareTag("Ground")) {
           isGrounded = false;
        }
    }

}
