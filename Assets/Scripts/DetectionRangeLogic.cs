using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRangeLogic : MonoBehaviour
{
    private List<GameObject> targList = new List<GameObject>();
    public CircleCollider2D _collider;
    // Start is called before the first frame update
    void Start()
    {
        int scale = transform.parent.GetComponent<AttackTowerLogic>().range;
        transform.localScale = new Vector3(scale, scale,1);
        _collider = gameObject.GetComponent<CircleCollider2D>();
        _collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(this.transform.parent.GetComponent<AttackTowerLogic>().target == null)
           if(targList.Count > 0)
               this.transform.parent.GetComponent<AttackTowerLogic>().target = targList[0];
       if(this.transform.parent.GetComponent<AttackTowerLogic>().canFire && !_collider.enabled) 
            _collider.enabled = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "VileVillain")
        {
            targList.Add(col.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "VileVillain")
        {
            Debug.Log("FuckYea");
            targList.Remove(col.gameObject);
            if(this.transform.parent.GetComponent<AttackTowerLogic>().target == col.gameObject)
                this.transform.parent.GetComponent<AttackTowerLogic>().target = null;
        }
    }
}
