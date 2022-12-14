using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject attackTower;
    public GameObject gManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateAttackTower()
    {
        gManager.GetComponent<GameManager>().SetSelectedUnit(
                Instantiate(attackTower, new Vector3(0, 0, 0), Quaternion.identity)
                );
    }

    public void StartGame()
    {
        SceneManager.LoadScene (sceneName:"Game");
    }
}
