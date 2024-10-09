using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public GameObject ConfirmationUI;
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowConfirmation()
    {
        ConfirmationUI.SetActive(true);
    }

    public void ChangeMap()
    {
        Time.timeScale = 1;
        if (sceneName == "Game")
        {
            SceneManager.LoadScene("Game2");
        }
        else if (sceneName == "Game2")
        {
            SceneManager.LoadScene("Game");
        }
        
    }

    public void CancelChange()
    {
        ConfirmationUI.SetActive(false);
    }
}
