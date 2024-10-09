using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievment : MonoBehaviour
{
    public GameObject achievementFirstTenCustomer;
    public GameObject firstHundredMoney;
    public GameObject throughtTheNight;
    public InGameUI inGameUI;
    public float money;
    public float score;
    public float throughNight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // money = PlayerPrefs.GetFloat("money");
        // score = PlayerPrefs.GetFloat("score");
        throughNight = PlayerPrefs.GetFloat("throughNight");

        money = inGameUI.getMoney();
        score = inGameUI.getScore();

        if (score > 900)
        {
            setAchievementFirstTenCustomerActive();
        }

        if (money > 99000)
        {
            setFirstHundredMoneyActive();
        }

        if (throughNight > 0)
        {
            setThroughtTheNightActive();
        }
    }

    public void setAchievementFirstTenCustomerActive()
    {
        achievementFirstTenCustomer.SetActive(false);
    }

    public void setFirstHundredMoneyActive()
    {
        firstHundredMoney.SetActive(false);
    }

    public void setThroughtTheNightActive()
    {
        throughtTheNight.SetActive(false);
    }



}
