using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private float camSpeed = 1f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        changeCamSpeed(PlayerPrefs.GetFloat("cameraSensitivity"));
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX * camSpeed;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY * camSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void changeCamSpeed(float speed)
    {
        camSpeed = speed;
    }
}