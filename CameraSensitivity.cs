using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSensitivity : MonoBehaviour
{
    [SerializeField] 
    public Slider camSensSlider;
    [SerializeField]
    public PlayerCam playerCam;

    public bool isTPS;
    // Start is called before the first frame update
    void Start()
    {
        // playerCam = GameObject.Find("PlayerCamTPS").GetComponent<PlayerCam>();
        isTPS = true;
        
        if(!PlayerPrefs.HasKey("cameraSensitivity"))
        {
            PlayerPrefs.SetFloat("cameraSensitivity", 1);
        }

        Load();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey("f"))
        // {
        //     if (isTPS)
        //     {
        //         playerCam = GameObject.Find("PlayerCamFPS").GetComponent<PlayerCam>();
        //     }
        //     else
        //     {
        //         playerCam = GameObject.Find("PlayerCamTPS").GetComponent<PlayerCam>();
        //     }
        //     ChangeCamSens();
        // }
    }

    public void ChangeCamSens()
    {
        playerCam.changeCamSpeed(camSensSlider.value);
        Save();
    }

    private void Load()
    {
        camSensSlider.value = PlayerPrefs.GetFloat("cameraSensitivity");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("cameraSensitivity", camSensSlider.value);
    }
}
