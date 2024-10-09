using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPositionBecak;
    public Transform cameraPositionAndong;
    public Transform cameraPositionTandu;
    public Transform cameraPositionCikar;
    public string vehicleName;
    public CameraScript cameraScript;

    private void Start()
    {
        vehicleName = cameraScript.getVehicleName();
    }

    private void Update()
    {
        if (vehicleName == "Becak")
        {
            transform.position = cameraPositionBecak.position;
        }
        else if (vehicleName == "Andong")
        {
            transform.position = cameraPositionAndong.position;
        }
        else if (vehicleName == "Tandu")
        {
            transform.position = cameraPositionTandu.position;
        }
        else if (vehicleName == "Cikar")
        {
            transform.position = cameraPositionCikar.position;
        }
    }

}
