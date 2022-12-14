using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject tower = null;
    public GameObject gameManager;
    public float speed = 5.0f;
    public int health = 1;
    public List<Tile> path = new List<Tile>();
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        tower = gameManager.GetComponent<GameManager>().tower;
    }

    // Update is called once per frame
    void Update()
    {
        if(tower == null)
            tower = GameObject.Find("Tower");
        if(health <= 0)
        {
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().addMoney(20);
        }
        if(tower != null && path.Count > 0)
        {
            float f = Vector2.Distance(
                        transform.position,
                        path[path.Count - 1].transform.position
                        );
            float fc = (float)Math.Round(f * 1000f) / 1000f;
            Debug.Log(
                    fc
                    );
            if(fc == 0)
            {
                path.RemoveAt(path.Count - 1);
            }
            Vector2 dir = (path[path.Count - 1].transform.position - this.transform.position).normalized;
            this.transform.position = new Vector2(this.transform.position.x + (dir.x * speed),
                                                  this.transform.position.y + (dir.y * speed));
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Tower")
        {
            tower.GetComponent<TowerLogic>().damage(1);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
    }

    public void setPath(List<Tile> _path)
    {
        path = _path;
        transform.position = path[path.Count - 1].transform.position;
        path.RemoveAt(path.Count - 1);
    }
}
