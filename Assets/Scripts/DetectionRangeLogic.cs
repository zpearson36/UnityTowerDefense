using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRangeLogic : MonoBehaviour
{
    private List<GameObject> targList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        int scale = transform.parent.GetComponent<AttackTowerLogic>().range;
        transform.localScale = new Vector3(scale, scale,1);
    }

    // Update is called once per frame
    void Update()
    {
            if(this.transform.parent.GetComponent<AttackTowerLogic>().target == null)
                if(targList.Count > 0)
                    this.transform.parent.GetComponent<AttackTowerLogic>().target = targList[0];
        
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
        }
    }
}
