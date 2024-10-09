using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public GameObject OpeningScene;
    public GameObject NextDayScene;
    public GameObject VehicleList;
    public Player player;
    public CameraScript cameraScript;
    public NpcAnimation npc;
    public InGameUI inGameUI;
    public Animator playerCutSceneAnim;
    public GameObject NpcFallScene;
    public GameObject NpcDisapointScene;
    public GameObject NpcGoToVehicleScene;
    public PlayerMovement playerMovement1;
    public PlayerMovement playerMovement2;
    public PlayerMovement playerMovement3;
    public PlayerMovement playerMovement4;
    public string vehicleName;
    IEnumerator waitNpcWalk;
    // Start is called before the first frame update
    void Start()
    {
        OpeningScene.SetActive(true);
        NextDayScene.SetActive(false);
        VehicleList.SetActive(false);
        StartCoroutine(ShowVehicleList());
        playerCutSceneAnim.SetBool("NotOpening", false);
        waitNpcWalk = waitForCutscene();

        if(!PlayerPrefs.HasKey("cameraSensitivity"))
        {
            PlayerPrefs.SetFloat("cameraSensitivity", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowVehicleList()
    {
        yield return new WaitForSeconds(16.6f);
        VehicleList.SetActive(true);
    }

    public void TurnOffOpeningScene()
    {
        OpeningScene.SetActive(false);
        playerCutSceneAnim.SetBool("NotOpening", true);
    }

    public void setNextDaySceneActive()
    {
        PlayerPrefs.SetFloat("throughNight", 1);
        cameraScript.SetPlayerCameraOff();
        NextDayScene.SetActive(true);
        StartCoroutine(SetupNewDay());
    }

    public void setNextDaySceneInactive()
    {
        NextDayScene.SetActive(false);
    }

    IEnumerator SetupNewDay()
    {
        yield return new WaitForSeconds(15.7f);
        setNextDaySceneInactive();
        player.BackToStart();
        npc.Respawn();
        inGameUI.RestartTime();
        cameraScript.SetPlayerCameraOn();
    }

    public void SetNpcFallScene()
    {
        cameraScript.SetPlayerCameraOff();
        NpcFallScene.SetActive(true);
    }

    public void SetNpcDisapointScene()
    {
        cameraScript.SetPlayerCameraOff();
        NpcDisapointScene.SetActive(true);
    }

    public void SetNpcToVehicleScene()
    {
        cameraScript.SetPlayerCameraOff();
        NpcGoToVehicleScene.SetActive(true);
    }

    public void SetOffNpcToVehicleScene()
    {
        cameraScript.SetPlayerCameraOn();
        NpcGoToVehicleScene.SetActive(false);
    }

    public void waitNpcCutsceneWalk()
    {
        vehicleName = cameraScript.getVehicleName();
        waitNpcWalk = waitForCutscene();
        StartCoroutine(waitNpcWalk);
        if (vehicleName == "Becak")
        {
            playerMovement1.stopVehicle();
        }
        else if (vehicleName == "Tandu")
        {
            playerMovement2.stopVehicle();
        }
        else if (vehicleName == "Andong")
        {
            playerMovement3.stopVehicle();
        }
        else if (vehicleName == "Cikar")
        {
            playerMovement4.stopVehicle();
        }     
    }

    IEnumerator waitForCutscene()
    {
        yield return new WaitForSeconds(3.2f);
        npc.NpcIsPickedUp();
        SetOffNpcToVehicleScene();
        if (vehicleName == "Becak")
        {
            playerMovement1.startVehicle();
        }
        else if (vehicleName == "Tandu")
        {
            playerMovement2.startVehicle();
        }
        else if (vehicleName == "Andong")
        {
            playerMovement3.startVehicle();
        }
        else if (vehicleName == "Cikar")
        {
            playerMovement4.startVehicle();
        }
        StopCoroutine(waitNpcWalk);
        yield return null;
    }
}
