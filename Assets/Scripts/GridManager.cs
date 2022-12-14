using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject gameManager;
    public Tile _tilePrefab;
    public Tile[,] tileArray;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateGrid()
    {
        int _width = gameManager.GetComponent<GameManager>().width;
        int _height = gameManager.GetComponent<GameManager>().height;
        tileArray = new Tile[_width, _height];
        for (int x = 0; x < _width; x++)
        {
            for(int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.GetComponent<Tile>().setColor(x + y);
                spawnedTile.GetComponent<Tile>().gameManager = gameManager;
                if((x == 6 && y <= (int) _height / 2) || (y == (int) _height / 2 && x > 6))
                    spawnedTile.GetComponent<Tile>().setAsRoad();
                tileArray[x, y] = spawnedTile;
            }
        }
    }

    public void AddUnitToTile(int x, int y, GameObject gameObject)
    {
        tileArray[x, y].GetComponent<Tile>().addUnit(gameObject);
    }
}
