using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject tower;
    public GameObject gameManager;
    public float speed = 5.0f;
    public int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.Find("Tower");
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().addMoney(20);
        }
        if(tower != null)
        {
            Vector2 dir = (tower.transform.position - this.transform.position).normalized;
            this.transform.position = new Vector2(this.transform.position.x + (dir.x * speed),
                                                  this.transform.position.y + (dir.y * speed));
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Tower")
        {
            tower.GetComponent<TowerLogic>().damage(1);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
    }
}
