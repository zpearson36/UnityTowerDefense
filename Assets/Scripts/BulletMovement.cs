using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public GameObject target = null;
    public float speed = .001f;
    private bool canDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            Vector2 dir = (target.transform.position - this.transform.position).normalized;
            this.transform.position = new Vector2(this.transform.position.x + (dir.x * speed),
                                                  this.transform.position.y + (dir.y * speed));
        }

        if(target == null && canDestroy)
        {
            Destroy(gameObject);
        }

    }

    public void SetTarget(GameObject targ)
    {
        target = targ;
        canDestroy = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "VileVillain")
        {
            Destroy(gameObject);
        }
    }
}
