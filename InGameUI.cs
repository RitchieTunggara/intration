using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] 
    private Text scoreUI;
    [SerializeField]
    private int score;
    [SerializeField] 
    private Text moneyUI;
    [SerializeField]
    private int money;
    [SerializeField] 
    private Text clockUI;

    public GameObject SettingCanvas;
    public GameObject InstructionCanvas;
    private int minute;
    private int hour;
    IEnumerator coroutineTime;
    public CameraScript cameraScript;
    public CutsceneManager cutsceneManager;
    public SpawnerCar spawnerCar;
    public GameObject ShopUI;
    public GameObject achievementUI;
    public GameObject mapUI;
    public AudioSource audioSource;
    public bool BellReady;
    public string UiOpen;
    // Start is called before the first frame update
    void Start()
    {
        UiOpen = "none";
        BellReady = false;
        coroutineTime = updateTimePerSecond();
        score = 0;
        scoreUI = GameObject.Find("Score").GetComponent<Text>();
        scoreUI.text = "Poin: " + score;

        money = 0;
        moneyUI = GameObject.Find("Money").GetComponent<Text>();
        moneyUI.text = "Rp. " + money;

        hour = 15;
        minute = 0;
        clockUI = GameObject.Find("Time").GetComponent<Text>();
        clockUI.text = hour + ":0" + minute;
        StartCoroutine(coroutineTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (hour >= 19)
        {
            hour = 0;
            spawnerCar.RestartSpawn();
            cameraScript.SetPlayerCameraOff();
            cutsceneManager.setNextDaySceneActive();
            StopCoroutine(coroutineTime);      
        }

        if (Input.GetKeyDown("space") && BellReady == true)
        {
            audioSource.Play();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (UiOpen == "none")
            {
                openSettingCanvas();
            }
            else if (UiOpen == "Setting")
            {
                closeSetting();
            }
            else if (UiOpen == "Instruction")
            {
                closeInstructionCanvas();
            }
            else if (UiOpen == "Shop")
            {
                closeShop();
            }
            else if (UiOpen == "Achievement")
            {
                closeAchievement();
            }
            else if (UiOpen == "Map")
            {
                closeMap();
            }
            
        }
    }

    public void updateScore(int scoreIncerase)
    {
        score = scoreIncerase;
        scoreUI.text = "Poin: " + score;
    }

    public int getScore()
    {
        return score;
    }

    public void updateMoney(int moneyIncrease)
    {
        money = moneyIncrease;
        moneyUI.text = "Rp. " + money;
    }

    public int getMoney()
    {
        return money;
    }

    public void openSettingCanvas()
    {
        SettingCanvas.SetActive(true);
        Time.timeScale = 0;
        UiOpen = "Setting";
    }

    public void closeSetting()
    {
        SettingCanvas.SetActive(false);
        Time.timeScale = 1;
        UiOpen = "none";
    }

    public void openInstructionCanvas()
    {
        InstructionCanvas.SetActive(true);
        Time.timeScale = 0;
        UiOpen = "Instruction";
    }

    public void closeInstructionCanvas()
    {
        InstructionCanvas.SetActive(false);
        Time.timeScale = 1;
        UiOpen = "none";
    }

    public void openShop()
    {
        ShopUI.SetActive(true);
        Time.timeScale = 0;
        UiOpen = "Shop";
    }

    public void closeShop()
    {
        ShopUI.SetActive(false);
        Time.timeScale = 1;
        UiOpen = "none";
    }

    public void openAchievement()
    {
        achievementUI.SetActive(true);
        Time.timeScale = 0;
        UiOpen = "Achievement";
    }

    public void closeAchievement()
    {
        achievementUI.SetActive(false);
        Time.timeScale = 1;
        UiOpen = "none";
    }

    public void openMap()
    {
        mapUI.SetActive(true);
        Time.timeScale = 0;
        UiOpen = "Map";
    }

    public void closeMap()
    {
        mapUI.SetActive(false);
        Time.timeScale = 1;
        UiOpen = "none";
    }

    public void updateTime()
    {
        
    }

    IEnumerator updateTimePerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(12f);
            if (minute < 59)
            {
                minute += 1;
            }
            else
            {
                minute = 0;
                hour += 1;
            }

            if (minute < 10)
            {
                clockUI.text = hour + ":0" + minute;
            }
            else
            {
                clockUI.text = hour + ":" + minute;
            }
        }
        
    }

    public void RestartTime()
    {
        hour = 15;
        minute = 0;
        clockUI.text = hour + ":0" + minute;
        StartCoroutine(coroutineTime);
    }

    public void SetBellReady()
    {
        BellReady = true;
    }
}
