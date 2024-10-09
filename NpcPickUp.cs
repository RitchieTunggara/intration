using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPickUp : MonoBehaviour
{
    [SerializeField]
    private NpcAnimation npcAnimation;
    public CutsceneManager cutsceneManager;
    public PlayerMovement playerMovement;
    public GameObject npc;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // npcAnimation.NpcIsPickedUp();
            
            // playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            cutsceneManager.SetNpcToVehicleScene();
            npc.SetActive(false);
            gameObject.SetActive(false);
            // playerMovement.stopVehicle();
            cutsceneManager.waitNpcCutsceneWalk();
            
            // StartCoroutine(waitForCutscene());
        }
    }

    IEnumerator waitForCutscene()
    {
        yield return new WaitForSeconds(3.2f);
        npcAnimation.NpcIsPickedUp();
        cutsceneManager.SetOffNpcToVehicleScene();
        playerMovement.startVehicle();
    }

    // public void SetObjectActive()
    // {
    //     gameObject.SetActive(true);
    // }

}
