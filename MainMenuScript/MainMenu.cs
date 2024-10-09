using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingCanvas;
    public GameObject infoCanvas;
    // Start is called before the first frame update
    void Start()
    {
        settingCanvas.SetActive(false);
        infoCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        settingCanvas.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void showInfo()
    {
        infoCanvas.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
