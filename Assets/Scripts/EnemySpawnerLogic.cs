using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLogic : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 5.0f;
    private float timeSinceSpawn = 5.0f; 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn >= spawnTime)
        {
            Instantiate(enemy, new Vector2(0, Random.Range(0, 10)), Quaternion.identity);
            timeSinceSpawn = 0.0f;
        }
    }
}
