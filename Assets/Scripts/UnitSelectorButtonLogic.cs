using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectorButtonLogic : MonoBehaviour
{
    public SpriteRenderer sr;
    public GameObject unit;
    public GameObject gManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        sr.color = Color.gray;
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gManager.GetComponent<GameManager>().SetSelectedUnit(
                    Instantiate(unit, new Vector3(0, 0, 0), Quaternion.identity)
                    );
        }
    }

    void OnMouseExit()
    {
        sr.color = Color.white;
    }
}
