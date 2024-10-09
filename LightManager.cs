using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotation = Vector3.zero;
    [SerializeField]
    private float degrerPerSec;
    private bool GameStart;
    IEnumerator rotatingLight;
    // Start is called before the first frame update
    void Start()
    {
        degrerPerSec = 0.025f;
        GameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStart)
        {
            rotation.x = degrerPerSec * Time.deltaTime;
            transform.Rotate(rotation, Space.World);
        }
        
    }

    public void GameIsStart()
    {
        GameStart = true;
        // StartCoroutine(rotatingLight);
    }

    // IEnumerator lightRotate()
    // {
    //     while(true)
    //     {
    //         yield return new WaitForSeconds(1f);
            
    //     }
    // }
}
