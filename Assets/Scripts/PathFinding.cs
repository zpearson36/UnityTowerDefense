using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    static GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class Node
    {
        public Tile tile;
        public Node parent = null;
        public float f = 0.0f;
        public float g = 0.0f;
        public float h = 0.0f;

        public Node(Tile _tile, Node _parent = null)
        {
            tile = _tile;
            parent = _parent;
        }

        public void updateF()
        {
            f = g + h;
        }
    }

    static public List<Tile> PathFind(Tile start_tile,Tile dest_tile)
    {
        Node start = new Node(start_tile);
        Node dest = new Node(dest_tile);
        List<Node> openList = new List<Node>();
        List<Node> closedList = new List<Node>();
        List<Node> children = new List<Node>();
        int[,] cardinals = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};
        openList.Add(start);
        bool done = false;
        Node currentNode = null;
        while(!done && openList.Count > 0)
        {
           currentNode = getLowestF(openList);
           closedList.Add(currentNode);
           if(currentNode.tile == dest.tile)
           {
               done = true;
               continue;
           }

           for(int i = 0; i < 4; i++)
           {
               int tmpX = (int)currentNode.tile.transform.position.x + cardinals[i, 0];
               int tmpY = (int)currentNode.tile.transform.position.y + cardinals[i, 1];

               if(tmpX < 0 || tmpX > gameManager.GetComponent<GameManager>().width ||
                  tmpY < 0 || tmpY > gameManager.GetComponent<GameManager>().height) continue;


               if(!gameManager.GetComponent<GameManager>().gridManager.GetComponent<GridManager>(
                          ).tileArray[tmpX, tmpY].GetComponent<Tile>().isRoad)
                   continue;

               children.Add(
                   new Node(
                       gameManager.GetComponent<GameManager>(
                           ).gridManager.GetComponent<GridManager>(
                               ).tileArray[tmpX, tmpY],
                       currentNode
                   )
               );
           }
           for(int i = 0; i < children.Count; i++)
           {
               if(isInList(closedList, children[i]) != -1) continue;
               children[i].g = currentNode.g + Vector2.Distance(children[i].tile.transform.position,
                       currentNode.tile.transform.position);
               children[i].h = Vector2.Distance(
                       children[i].tile.transform.position,
                       dest.tile.transform.position
                       );
               children[i].updateF();
               int tmp = isInList(openList, children[i]);
               if(tmp != -1 && children[i].g > openList[tmp].g) continue;
               openList.Add(children[i]);
           }

        }

        List<Tile> path = new List<Tile>();
        while(currentNode.parent != null)
        {
            path.Add(currentNode.tile);
            currentNode = currentNode.parent;
        }

        return path;
    }

    static int isInList(List<Node> list, Node node)
    {
        int retVal = -1;
        for(int i = 0; i < list.Count; i++)
        {
            if(list[i].tile == node.tile)
            {
                retVal = i;
                break;
            }
        }

        return retVal;
    }

    static Node getLowestF(List<Node> list)
    {
        Node tmp = null;
        int tmpI = 0;

        for(int i = 0; i < list.Count; i++)
        {
            if(tmp == null)
                tmp = list[i];
            else if(list[i].f < tmp.f)
            {
                tmp = list[i];
                tmpI = i;
            }
        }

        list.RemoveAt(tmpI);
        return tmp;
    }
}
