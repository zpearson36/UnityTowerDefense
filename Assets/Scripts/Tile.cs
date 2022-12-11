using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject unit, gameManager;
    public bool isHovering = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      // if(unit == null &&
      //    isHovering &&
      //    gameManager.GetComponent<GameManager>().selectedUnit != null &&
      //    Input.GetMouseButtonDown(0))
      // {
      //     Debug.Log("poop");
      //     unit = gameManager.GetComponent<GameManager>().placeUnit();
      //     if(unit != null)
      //         unit.transform.position = transform.position;
      // }
    }

    public void setColor(int _val)
    {
        spriteRenderer.color = new Color(.6f, .6f, .6f, 1.0f);
        if(_val % 2 == 0)
            spriteRenderer.color = new Color(.5f, .5f, .5f, 1.0f);
    }

    void OnMouseOver()
    {
        isHovering = true;
    }

    void OnMouseExit()
    {
        isHovering = false;
    }

    public void addUnit(GameObject _unit)
    {
        unit = _unit;
        unit.transform.position = transform.position;
        unit.GetComponent<AttackTowerLogic>().canFire = true;
    }
}
