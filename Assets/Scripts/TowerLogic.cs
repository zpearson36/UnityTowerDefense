using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLogic : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
            Destroy(gameObject);
    }

    public void damage(int dmg)
    {
        health -= dmg;
    }
}