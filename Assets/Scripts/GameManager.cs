using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject selectedUnit;
    public GameObject tower;
    public bool started = false;
    public GameObject spawner;
    public Camera cam;
    private bool canPlace = false;
    public int playerMoney;
    public Text moneyDisplay;
    public int width, height, wave;
    private float[,] waveInfo = {
        {5f, 3f},
        {5f, 1f},
        {15f, 1f},
        {25f, 1f},
        {30f, .5f},
    };
    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
        moneyDisplay.text = playerMoney.ToString();
        //tower = Instantiate(tower, new Vector2((float) width - 2, (float) height / 2), Quaternion.identity);
        tower.transform.position = new Vector2((float) width - 2, (float) height / 2);
        cam.transform.position = new Vector3((float) width / 2 - 0.5f, 
                                             (float) height / 2 - 0.5f,
                                             -10);
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            started = !started;
        }
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
                
                RaycastHit2D[] hits = Physics2D.RaycastAll(cam.ScreenPointToRay(Input.mousePosition).origin,cam.ScreenPointToRay(Input.mousePosition).direction);
                foreach(RaycastHit2D hit in hits)
                {
                    if(hit.collider.gameObject.tag == "Tile")
                    {
                        Debug.Log(hit.collider.gameObject.name);
                        if(playerMoney >= selectedUnit.GetComponent<AttackTowerLogic>().cost)
                        {
                            subMoney(selectedUnit.GetComponent<AttackTowerLogic>().cost);
                            hit.collider.gameObject.GetComponent<Tile>().addUnit(selectedUnit);
                            selectedUnit = null;
                            canPlace = false;
                        }
                        break;
                    }
                }
            }
        }

        if(selectedUnit != null)
            canPlace = true;

        if(spawner.GetComponent<EnemySpawnerLogic>().waveLaunched &&
           GameObject.FindGameObjectsWithTag("VileVillain").Length == 0)
        {
            spawner.GetComponent<EnemySpawnerLogic>().StartWave((int)waveInfo[wave, 0], waveInfo[wave, 1]);
            wave++;
        }
        if(wave >= 5)
            wave = 0;
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

    public GameObject placeUnit()
    {
        GameObject tmpUnit = null;
        if(playerMoney >= selectedUnit.GetComponent<AttackTowerLogic>().cost)
        {
            tmpUnit = selectedUnit;
            subMoney(selectedUnit.GetComponent<AttackTowerLogic>().cost);
            selectedUnit.GetComponent<AttackTowerLogic>().canFire = true;
            selectedUnit = null;
            canPlace = false;
        }

        return tmpUnit;
    }
}
