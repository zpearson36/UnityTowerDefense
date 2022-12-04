using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selectedUnit;
    public Camera cam;
    private bool canPlace = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Tower") == null)
        {
            Application.Quit();
        }

        if(canPlace)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            selectedUnit.transform.position = new Vector2(mousePos.x, mousePos.y);
            if(Input.GetMouseButtonDown(1))
            {
                Destroy(selectedUnit);
                selectedUnit = null;
                canPlace = false;
            }
            if(Input.GetMouseButtonDown(0))
            {
                selectedUnit.GetComponent<AttackTowerLogic>().canFire = true;
                selectedUnit = null;
                canPlace = false;
            }
        }

        if(selectedUnit != null)
            canPlace = true;
    }

    public void SetSelectedUnit(GameObject _unit)
    {
        if(selectedUnit != null)
        {
            Destroy(selectedUnit);
        }
        selectedUnit = _unit;
        canPlace = false;
    }
}
