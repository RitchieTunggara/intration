using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCar : MonoBehaviour
{
    public GameObject[] obj;
    public Transform spawnDest;
    public bool Spawning = true;
    public float SpawnTime = 60f;
    IEnumerator spawnCar;
    GameObject CarCloneLists;
    public int counter;
    int randNum;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTime = 60f;
        counter = 0;
        spawnCar = spawning();
        CarCloneLists = (GameObject)Instantiate(obj[randNum], spawnDest.position, spawnDest.rotation);
        StartCoroutine(spawnCar);
    }

    public void RestartSpawn()
    {
        // foreach 
        Destroy(CarCloneLists);
        StopCoroutine(spawnCar);
        CarCloneLists = (GameObject)Instantiate(obj[randNum], spawnDest.position, spawnDest.rotation);
        StartCoroutine(spawnCar);
    }

    IEnumerator spawning()
    {
        while(Spawning == true)
        {
            yield return new WaitForSeconds(SpawnTime);
            randNum = Random.Range(0, 3);
            CarCloneLists = (GameObject)Instantiate(obj[randNum], spawnDest.position, spawnDest.rotation);
            counter++;
        }
    }
}
