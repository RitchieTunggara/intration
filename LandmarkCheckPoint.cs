using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkCheckPoint : MonoBehaviour
{
    bool checkInsideArea;
    int score;
    public float borderX, borderZ;
    Collider myCollider;

    public List<GameObject> checkpointIn;
    public List<GameObject> checkpointOut;

    public GameObject FinishArea;

    private bool checkForOut;
    public int counter;

    public Player player;

    [SerializeField]
    private NpcAnimation npcAnimation;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;

        checkForOut = false;

        setAllCpInactive();

        checkpointIn[0].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setAllCpInactive()
    {
        foreach (GameObject cpIn in checkpointIn)
        {
            cpIn.SetActive(false);
        }

        foreach (GameObject cpOut in checkpointOut)
        {
            cpOut.SetActive(false);
        }
        FinishArea.SetActive(false);
    }

    private void setCpActive()
    {
        if (checkForOut == false)
        {
            checkForOut = true;
            checkpointIn[counter].SetActive(false);
            checkpointOut[counter].SetActive(true);
        }
        else if (checkForOut == true)
        {
            checkForOut = false;
            player.updateScore();
            checkpointOut[counter].SetActive(false);
            counter++;
            if (counter < checkpointOut.Count)
            {
                
                checkpointIn[counter].SetActive(true);
            }
            else
            {
                FinishArea.SetActive(true);
            }
        }

        // setAllCpInactive();
        // checkpointIn[order].SetActive(true);
        // checkpointOut[order].SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            if (counter < checkpointOut.Count)
            {
                setCpActive();
            }
            else
            {
                checkpointIn[0].SetActive(true);
                FinishArea.SetActive(false);
                player.updateMoney();

                npcAnimation = GameObject.Find("NpcNew").GetComponent<NpcAnimation>();
                npcAnimation.NpcIsFinished();
                
                counter = 0;
            }
            
        }
    }

}
