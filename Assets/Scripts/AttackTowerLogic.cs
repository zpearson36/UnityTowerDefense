using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTowerLogic : MonoBehaviour
{
    public GameObject target = null;
    public GameObject bullet = null;
    public int cost = 100;
    public int range = 5;
    public bool canFire = false;
    public float fireTime = 3.0f;
    public float timeSinceFired = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceFired += Time.deltaTime;
        if(canFire)
        {
            if(target != null && timeSinceFired >= fireTime)
            {
                GameObject tmpBullet = Instantiate(bullet, this.transform.position, Quaternion.identity);
                tmpBullet.GetComponent<BulletMovement>().SetTarget(target);
                timeSinceFired = 0.0f;
            }
        }
    }
}
