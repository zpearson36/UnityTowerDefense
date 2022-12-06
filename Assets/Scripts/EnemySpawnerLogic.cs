using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLogic : MonoBehaviour
{
    public GameObject enemy;
    public int spawnNum = 1;
    public float spawnTime = 5.0f;
    public bool waveLaunched = true;
    private float timeSinceSpawn = 5.0f; 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn >= spawnTime && spawnNum > 0)
        {
            Instantiate(enemy, new Vector2(0, Random.Range(0, 10)), Quaternion.identity);
            spawnNum--;
            timeSinceSpawn = 0;
        }
        if(spawnNum == 0)
            waveLaunched = true;
    }

    public void StartWave(int spawnCount, float spawnInterval)
    {
        spawnNum = spawnCount;
        spawnTime = spawnInterval;
        waveLaunched = false;
    }
}
