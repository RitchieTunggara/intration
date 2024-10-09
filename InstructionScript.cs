using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5Becak;
    public GameObject panel5Tandu;
    public GameObject panel5Andong;
    public GameObject panel5Cikar;
    public GameObject canvas;
    public GameObject UiInGame;
    public string vehicle;
    public CameraScript cameraScript;

    // Start is called before the first frame update
    void Start()
    {
        // Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextFromPanel1()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }

    public void nextFromPanel2()
    {
        panel2.SetActive(false);
        panel3.SetActive(true);
    }

    public void nextFromPanel3()
    {
        panel3.SetActive(false);
        panel4.SetActive(true);
    }

    public void nextFromPanel4()
    {
        panel4.SetActive(false);
        vehicle = cameraScript.getVehicleName();
        if (vehicle == "Becak")
        {
            panel5Becak.SetActive(true);
        }
        else if (vehicle == "Tandu")
        {
            panel5Tandu.SetActive(true);
        }
        else if (vehicle == "Andong")
        {
            panel5Andong.SetActive(true);
        }
        else if (vehicle == "Cikar")
        {
            panel5Cikar.SetActive(true);
        }
        
    }

    public void nextFromPanel5Becak()
    {
        panel5Becak.SetActive(false);
        panel1.SetActive(true);
        canvas.SetActive(false);
        UiInGame.SetActive(true);
        Time.timeScale = 1;
    }

    public void nextFromPanel5Tandu()
    {
        panel5Tandu.SetActive(false);
        panel1.SetActive(true);
        canvas.SetActive(false);
        UiInGame.SetActive(true);
        Time.timeScale = 1;
    }

    public void nextFromPanel5Andong()
    {
        panel5Andong.SetActive(false);
        panel1.SetActive(true);
        canvas.SetActive(false);
        UiInGame.SetActive(true);
        Time.timeScale = 1;
    }

    public void nextFromPanel5Cikar()
    {
        panel5Cikar.SetActive(false);
        panel1.SetActive(true);
        canvas.SetActive(false);
        UiInGame.SetActive(true);
        Time.timeScale = 1;
    }

    public void backFromPanel2()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);
    }

    public void backFromPanel3()
    {
        panel2.SetActive(true);
        panel3.SetActive(false);
    }

    public void backFromPanel4()
    {
        panel3.SetActive(true);
        panel4.SetActive(false);
    }

    public void backFromPanel5Becak()
    {
        panel4.SetActive(true);
        panel5Becak.SetActive(false);
    }

    public void backFromPanel5Tandu()
    {
        panel4.SetActive(true);
        panel5Tandu.SetActive(false);
    }

    public void backFromPanel5Andong()
    {
        panel4.SetActive(true);
        panel5Andong.SetActive(false);
    }

    public void backFromPanel5Cikar()
    {
        panel4.SetActive(true);
        panel5Cikar.SetActive(false);
    }
}
