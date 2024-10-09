using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingVehicle : MonoBehaviour
{
    public GameObject Becak;
    public GameObject Tandu;
    public GameObject Andong;
    public GameObject Cikar;
    
    public GameObject cameraController;

    private CameraScript cameraScript;
    [SerializeField]
    private CutsceneManager cutsceneManager;
    // Start is called before the first frame update
    void Start()
    {
        cameraScript = cameraController.GetComponent<CameraScript>();
        cutsceneManager = GameObject.Find("Cutscene").GetComponent<CutsceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpPlayer()
    {
        gameObject.SetActive(false);
        cutsceneManager.TurnOffOpeningScene();
        // cameraScript.StartTheGameBecak();
    }

    public void ChooseBecak()
    {
        SetUpPlayer();
        cameraScript.StartTheGameBecak();
        // Becak.SetActive(true);
    }

    public void ChooseTandu()
    {
        SetUpPlayer();
        cameraScript.StartTheGameTandu();
    }

    public void ChooseAndong()
    {
        SetUpPlayer();
        cameraScript.StartTheGameAndong();
        // Andong.SetActive(true);
    }

    public void ChooseCikar()
    {
        SetUpPlayer();
        cameraScript.StartTheGameCikar();
    }

}
