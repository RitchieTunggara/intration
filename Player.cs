using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int score;
    private int money;
    [SerializeField]
    private int MaxHealth = 100;
    [SerializeField]
    private int currentHealth;
    public Animator animator;
    public bool gameStart;

    public InGameUI inGameUI;
    public HealthBar healthbar;
    public Transform spawnLocation;

    public GameObject GameOverCanvas;
    public NpcAnimation Npc;
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 100;
        score = 0;
        money = 0;
        // inGameUI = GameObject.Find("ingameUI").GetComponent<InGameUI>();
        currentHealth = MaxHealth;
        // healthbar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        healthbar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            animator.SetBool("isGameStarted", true);
        }

        if (Input.GetKey("m"))
        {
            money = 10000000; 
            inGameUI.updateMoney(money);      
        }

    }

    public void updateScore()
    {
        score += 100;
        // Debug.Log(score);
        PlayerPrefs.SetFloat("score", score);
        inGameUI.updateScore(score);
    }

    public void updateMoney()
    {
        money += 15000;
        PlayerPrefs.SetFloat("money", money);
        inGameUI.updateMoney(money);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);

        // BackToStart();

        if (currentHealth <= 0)
        {
            GameOverCanvas.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject.tag);
        // if(collision.gameObject.tag == "Npc")
        // {
            // Destroy(collision.gameObject);
            // Npc.DisableGameObject();
            // TakeDamage(20);
        // }
        if(collision.gameObject.tag == "Object")
        {
            TakeDamage(20);
        }
    }

    public void BackToStart()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = spawnLocation.position;
    }

    public int checkMoney()
    {
        return money;
    }

    public void decreaseMoney(int price)
    {
        money -= price;
        inGameUI.updateMoney(money);  
    }

    public void heal()
    {
        int heal = (MaxHealth-currentHealth) * -1;
        TakeDamage(heal);
    }

}
