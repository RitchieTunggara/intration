using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour
{
    public float rotate = 0f;
    public float rotateSpeed = 0.3f;
    public float exposureSpeed = 0.0001f;
    public float exposure = 0.5f;
    IEnumerator exposureTime;
    void Start()
    {
        exposure = 0.7f;
        exposureSpeed = 0.001f;
        exposureTime = exposureTimer();
        RenderSettings.skybox.SetFloat("_Exposure", exposure);
        StartCoroutine(exposureTime);
    }
    void Update()
    {
        rotate = Time.time * rotateSpeed;
        RenderSettings.skybox.SetFloat("_Rotation", rotate);
        if (rotate >= 360)
        {
            rotate = 0;
        }

        // exposureInitial -= Time.time * exposureSpeed;
        // RenderSettings.skybox.SetFloat("_Exposure", exposureInitial);
    }

    IEnumerator exposureTimer()
    {
        while (exposure > 0.05)
        {
            yield return new WaitForSeconds(15f);
            exposure -= exposureSpeed;
            RenderSettings.skybox.SetFloat("_Exposure", exposure);
        }
    }
}
