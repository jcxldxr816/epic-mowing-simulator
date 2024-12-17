using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    public GameObject fakePlayerBody;

    float xRotation = 0f;

    public bool disableLook = false;

    public bool shiftLook = false;

    public void mowerLook()
    {
        disableLook = true;
    }

    public void mowerLookOff()
    {
        disableLook = false;
    }

    public void mowerLookShift(bool x)
    {
        if (x ==true)
        {
            shiftLook = true;
        }
        else
        {
            shiftLook = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!disableLook)
        {
            float mouseX = Input.GetAxis("MouseX") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("MouseY") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            
            if (shiftLook == true)
            {
                playerBody.RotateAround(fakePlayerBody.transform.position, Vector3.up, mouseX);
                //Debug.Log("rotating....");
            }
            else
            {
                playerBody.Rotate(Vector3.up * mouseX);
            }
        }
    }
}