using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject confirmationToMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameObject bgMusic = GameObject.FindGameObjectWithTag("Music");
        Destroy(bgMusic);
    }

    public void showConfirmation()
    {
        confirmationToMenu.SetActive(true);
    }

    public void closeConfirmation()
    {
        confirmationToMenu.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
}
