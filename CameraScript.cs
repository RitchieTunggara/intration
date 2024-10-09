using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject CameraCutScene;
    bool cameraTpsCheck;
    private bool GameStart;
    
    public GameObject playerBecak;
    public GameObject playerAndong;
    public GameObject playerTandu;
    public GameObject playerCikar;
    public PlayerMovement playerMovementBecak;
    public PlayerMovement playerMovementAndong;
    public PlayerMovement playerMovementTandu;
    public PlayerMovement playerMovementCikar;

    public List<GameObject> objectToSpawn;

    private LightManager lightManager;
    private string vehicleName;
    
    // Start is called before the first frame update
    void Start()
    {
        // playerMovement = player.GetComponent<PlayerMovement>();
        cameraTpsCheck = true;
        GameStart = false;
        SetPlayerCameraOff();
        CameraCutScene.SetActive(true);

        lightManager = GameObject.Find("Directional Light").GetComponent<LightManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && GameStart == true)
        {
            CameraChange();
        }
    }

    void CameraChange()
    {
        if (cameraTpsCheck)
        {
            Camera1.SetActive(true);
            Camera2.SetActive(false);
            cameraTpsCheck = false;
        }
        else
        {
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            cameraTpsCheck = true;
        }
    }

    public void StartTheGameBecak()
    {
        GameStart = true;
        CameraCutScene.SetActive(false);
        Camera2.SetActive(true);
        
        vehicleName = "Becak";
        playerBecak.SetActive(true);
        StartCoroutine(startGameForPlayer());

        foreach (GameObject i in objectToSpawn)
        {
            i.SetActive(true);
        }

        lightManager.GameIsStart();

    }

    public void StartTheGameAndong()
    {
        GameStart = true;
        CameraCutScene.SetActive(false);
        Camera2.SetActive(true);
        
        vehicleName = "Andong";
        playerAndong.SetActive(true);
        StartCoroutine(startGameForPlayer());

        foreach (GameObject i in objectToSpawn)
        {
            i.SetActive(true);
        }

        lightManager.GameIsStart();

    }

    public void StartTheGameTandu()
    {
        GameStart = true;
        CameraCutScene.SetActive(false);
        Camera2.SetActive(true);
        
        vehicleName = "Tandu";
        playerTandu.SetActive(true);
        StartCoroutine(startGameForPlayer());

        foreach (GameObject i in objectToSpawn)
        {
            i.SetActive(true);
        }

        lightManager.GameIsStart();

    }

    public void StartTheGameCikar()
    {
        GameStart = true;
        CameraCutScene.SetActive(false);
        Camera2.SetActive(true);
        
        vehicleName = "Cikar";
        playerCikar.SetActive(true);
        StartCoroutine(startGameForPlayer());

        foreach (GameObject i in objectToSpawn)
        {
            i.SetActive(true);
        }

        lightManager.GameIsStart();

    }

    public void SetPlayerCameraOff()
    {
        Camera1.SetActive(false);
        Camera2.SetActive(false);
        CameraCutScene.SetActive(true);
        GameStart = false;
    }

    public void SetPlayerCameraOn()
    {
        Camera1.SetActive(false);
        Camera2.SetActive(true);
        CameraCutScene.SetActive(false);
        GameStart = true;
    }

    IEnumerator startGameForPlayer()
    {
        yield return new WaitForSeconds(1f);
        if (vehicleName == "Becak")
        {
            playerMovementBecak.StartTheGame();
        }
        else if (vehicleName == "Andong")
        {
            playerMovementAndong.StartTheGame();
        }
        else if (vehicleName == "Tandu")
        {
            playerMovementTandu.StartTheGame();
        }
        else if (vehicleName == "Cikar")
        {
            playerMovementCikar.StartTheGame();
        }
        
    }

    public string getVehicleName()
    {
        return vehicleName;
    }
}
