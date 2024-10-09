using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject settingCanvas;
    public GameObject confirmationQuitCanvas;
    public GameObject selectedGraphicLow;
    public GameObject selectedGraphicMedium;
    public GameObject selectedGraphicHigh;
    public string graphic;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("graphic"))
        {
            QualitySettings.SetQualityLevel(5, false);
            selectedGraphicHigh.SetActive(true);
            SetQualityToUltra();
        }

        else
        {
            graphic = PlayerPrefs.GetString("graphic");   
            if (graphic == "High")
            {
                SetQualityToUltra();
            }
            else if (graphic == "Medium")
            {
                SetQualityToHigh();
            }
            else if (graphic == "Low")
            {
                SetQualityToLow();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showConfirmationQuit()
    {
        confirmationQuitCanvas.SetActive(true);
    }

    public void closeConfirmationQuit()
    {
        confirmationQuitCanvas.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
        
    }

    public void closeSetting()
    {
        settingCanvas.SetActive(false);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameObject bgMusic = GameObject.FindGameObjectWithTag("Music");
        Destroy(bgMusic);
    }

    public void SetQualityToUltra()
    {
        QualitySettings.SetQualityLevel(5, false);
        inactiveAllSelected();
        selectedGraphicHigh.SetActive(true);
        PlayerPrefs.SetString("graphic", "High");
    }

    public void SetQualityToHigh()
    {
        QualitySettings.SetQualityLevel(3, false);
        inactiveAllSelected();
        selectedGraphicMedium.SetActive(true);
        PlayerPrefs.SetString("graphic", "Medium");
    }

    public void SetQualityToLow()
    {
        QualitySettings.SetQualityLevel(1, false);
        inactiveAllSelected();
        selectedGraphicLow.SetActive(true);
        PlayerPrefs.SetString("graphic", "Low");
    }

    public void inactiveAllSelected()
    {
        selectedGraphicHigh.SetActive(false);
        selectedGraphicMedium.SetActive(false);
        selectedGraphicLow.SetActive(false);
    }
}
