using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject selectedUnit;
    public GameObject tower;
    public Camera cam;
    private bool canPlace = false;
    public int playerMoney;
    public Text moneyDisplay;
    public int width, height;
    // Start is called before the first frame update
    void Start()
    {
        moneyDisplay.text = playerMoney.ToString();
        tower = Instantiate(tower, new Vector2((float) width - 2, (float) height / 2), Quaternion.identity);
        cam.transform.position = new Vector3((float) width / 2 - 0.5f, 
                                             (float) height / 2 - 0.5f,
                                             -10);
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
                if(playerMoney >= selectedUnit.GetComponent<AttackTowerLogic>().cost)
                {
                    subMoney(selectedUnit.GetComponent<AttackTowerLogic>().cost);
                    selectedUnit.GetComponent<AttackTowerLogic>().canFire = true;
                    selectedUnit = null;
                    canPlace = false;
                }
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

    public void addMoney(int income)
    {
        playerMoney += income;
        moneyDisplay.text = playerMoney.ToString();
    }

    public void subMoney(int cost)
    {
        playerMoney -= cost;
        moneyDisplay.text = playerMoney.ToString();
    }
}
