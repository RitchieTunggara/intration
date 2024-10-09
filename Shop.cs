using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int money;
    public Player player;
    public PlayerMovement playerMovement;
    public InGameUI inGameUI;
    public GameObject soldIcon;

    public Player playerBecak;
    public Player playerAndong;
    public Player playerTandu;
    public Player playerCikar;
    public PlayerMovement playerMovementBecak;
    public PlayerMovement playerMovementAndong;
    public PlayerMovement playerMovementTandu;
    public PlayerMovement playerMovementCikar;
    public CameraScript cameraScript;
    public string vehicleName;
    public NpcAnimation npc;
    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.Find("Player").GetComponent<Player>();
        // playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        // player = FindGameObjectsWithTag("Player").GetComponent(Player);
        // playerMovement = FindGameObjectsWithTag("Player").GetComponent(PlayerMovement);
        soldIcon.SetActive(false);

        vehicleName = cameraScript.getVehicleName();
        if (vehicleName == "Becak")
        {
            player = playerBecak;
            playerMovement = playerMovementBecak;
        }
        else if (vehicleName == "Tandu")
        {
            player = playerTandu;
            playerMovement = playerMovementTandu;
        }
        else if (vehicleName == "Andong")
        {
            player = playerAndong;
            playerMovement = playerMovementAndong;
        }
        else if (vehicleName == "Cikar")
        {
            player = playerCikar;
            playerMovement = playerMovementCikar;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyHonk()
    {
        money = player.checkMoney();
        if (money > 100000)
        {
            soldIcon.SetActive(true);
            inGameUI.SetBellReady();
            player.decreaseMoney(100000);
        }
    }

    public void buyHealth()
    {
        money = player.checkMoney();
        if (money > 100000)
        {
            player.heal();
            player.decreaseMoney(100000);
        }
    }

    public void buySpeed()
    {
        money = player.checkMoney();
        if (money > 1000000)
        {
            playerMovement.increaseSpeed();
            player.decreaseMoney(1000000);
            npc.increaseSpeed();
        }
    }
}
