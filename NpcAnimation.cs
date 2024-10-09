using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimation : MonoBehaviour
{
    public Animator NpcAnim;
    public GameObject stopPoint;

    private Rigidbody rb;
    Vector3 rotationRight = new Vector3(0, 15, 0);
    Vector3 rotationLeft = new Vector3(0, -15, 0);

    [SerializeField]
    private Transform npcPosition;
    [SerializeField]
    private Transform npcFinishLocation;
    [SerializeField]
    private Transform npcStartLocation;
    private bool isNpsPickedUp = false;

    public AudioSource MyAudioSource;
    public bool isWalk;

    [SerializeField]
    public GameObject pickUpPointNPC;
    
    public GameObject[] LandmarkCP;
    public GameObject[] LinePoints;
    public GameObject[] LinePathway;

    public GameObject Timer;
    public ClientTimeBar clientTimeBar;

    public int maxTime;
    public int time;

    public Player player;
    public waypointMover wpMover;
    IEnumerator coUpdateTime;
    public CutsceneManager cutSceneManager;
    public string vehicle;
    public CameraScript cameraScript;
    public int rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = 15;
        coUpdateTime = updateTimerEverySecond();
        NpcAnim = GetComponentInChildren<Animator>();
        NpcAnim.SetBool("IsWalk", true);
        rb = GetComponent<Rigidbody>();

        npcPosition = GameObject.Find("NpcPos").GetComponent<Transform>();
        npcFinishLocation = GameObject.Find("NpcFinishLocation").GetComponent<Transform>();
        stopPoint = GameObject.Find("WaypointNPC3");
        npcPosition = GameObject.Find("NpcPos").GetComponent<Transform>();
        npcFinishLocation = GameObject.Find("NpcFinishLocation").GetComponent<Transform>();


        MyAudioSource = GetComponentInChildren<AudioSource>();

        isWalk = true;
        // MyAudioSource.Play();

        maxTime = 480;
        time = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        rotationRight = new Vector3(0, rotation, 0);
        rotationLeft = new Vector3(0, -(rotation), 0);
        float distToStopPos = Vector3.Distance(stopPoint.transform.position, transform.position);
        if (distToStopPos < 0.2f)
        {
            NpcAnim.SetBool("IsWalk", false);
            isWalk = false;
            if (isNpsPickedUp == false)
            {
                pickUpPointNPC.SetActive(true);
            }
        }

        if (isNpsPickedUp == true)
        {
            // transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = npcPosition.position;
            pickUpPointNPC.SetActive(false);
            // isNpcPickUp(true);
        }

        if (isWalk == true)
        {
            // MyAudioSource.Play();
        }
        else
        {
            MyAudioSource.Stop();
        }
    }

    private void FixedUpdate()
    {
        if (isNpsPickedUp)
        {
            MovePlayer();
        }   
    }

    public void increaseSpeed()
    {
        rotation *= 3;
    }

    // public void isNpcPickUp(bool pickUp)
    // {
    //     NpcAnim.SetBool("IsWalk", false);
        
    // }

    private void MovePlayer()
    {
        if (Input.GetKey("d"))
        {
            Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationRight);
        }

        if (Input.GetKey("a"))
        {
            Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }
    }

    public void NpcIsPickedUp()
    {
        gameObject.SetActive(true);
        GetComponentInChildren<Collider>().enabled = false;
        isNpsPickedUp = true;

        vehicle = cameraScript.getVehicleName();

        if (vehicle == "Cikar")
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        } 
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
        NpcAnim.SetBool("isNpcPickUp", true);

        PreparePathway();
        int random = Random.Range(0, 3);
        Debug.Log(random);
        LandmarkCP[random].SetActive(true);
        LinePoints[random].SetActive(true);
        LinePathway[random].SetActive(true);

        Timer.SetActive(true);
        clientTimeBar.SetMaxTime(maxTime);
        StartCoroutine(coUpdateTime);
    }

    public void NpcIsFinished()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        transform.position = npcFinishLocation.position;
        isNpsPickedUp = false;
        NpcAnim.SetBool("isNpcPickUp", false);
        Timer.SetActive(false);
        PreparePathway();
        StopCoroutine(coUpdateTime);
        StartCoroutine(RespawnNpc());
    }

    public void PreparePathway()
    {
        for (int i=0; i<LandmarkCP.Length; i++)
        {
            LandmarkCP[i].SetActive(false);
            LinePoints[i].SetActive(false);
            LinePathway[i].SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            pickUpPointNPC.SetActive(false);
            MyAudioSource.Stop();
            cutSceneManager.SetNpcFallScene();
        }
    }

    IEnumerator updateTimerEverySecond()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            time -= 1;
            clientTimeBar.SetTime(time);
            if (time == 0)
            {
                NpcIsFinished();
                Timer.SetActive(false);
                player.BackToStart();
                cutSceneManager.SetNpcDisapointScene();
                yield return null;
            }
        }
    }

    // public void DisableGameObject()
    // {
    //     gameObject.SetActive(false);
    //     Respawn();
    // }

    public void Respawn()
    {
        // gameObject.SetActive(true);
        transform.position = npcStartLocation.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        isWalk = true;
        NpcAnim.SetBool("IsWalk", true);
        time = maxTime;
        wpMover.Restart();
        MyAudioSource.Play();
    }

    // public bool isNpcOnVehicle()
    // {

    // }

    IEnumerator RespawnNpc()
    {
        yield return new WaitForSeconds(2.5f);
        Respawn();
    }

    public void StartWalkSound()
    {
        MyAudioSource.Play();
    }
}
