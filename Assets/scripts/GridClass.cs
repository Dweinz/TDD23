using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridClass : MonoBehaviour {

    public static GridClass me;
    TileMaster[,] TilesGrid;
    public GameObject prefabTile1;
    public GameObject prefabTile2;
    public GameObject prefabTile3;
    public GameObject playerPrefab;
    public Vector2 GridDimension;
    // Use this for initialization
    private void Awake()
    {
        me = this;
        TilesGrid = new TileMaster[(int)GridDimension.x, (int)GridDimension.y];
    }
    void Start () {
        generateGrid();
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void generateGrid()
    {
        Vector3 playerStartPos = new Vector3(0, 0, 0);
        GameObject startCharacter = (GameObject)Instantiate(playerPrefab,playerStartPos, Quaternion.Euler(0, 0, 0));
        GameObject startCharacter2 = (GameObject)Instantiate(playerPrefab,new Vector3(0,1,0), Quaternion.Euler(0, 0, 0));

        for (int x = 0; x < GridDimension.x; x++)
        {
            for(int y = 0; y < GridDimension.y; y++)
            {
                Vector3 posToCreatetile = new Vector3(x, y, 0);
                GameObject recentTile = (GameObject)Instantiate(prefabTile1, posToCreatetile, Quaternion.Euler(0, 0, 0));
                recentTile.GetComponent<TileMaster>().setGridCoords(new Vector2(x, y));
                recentTile.transform.parent = this.gameObject.transform;
                TilesGrid[x, y] = recentTile.GetComponent<TileGrass>();

            }
        }
    }
    public List<GameObject> getTiles(Vector2 startPos, Vector2 endPos)
    {
        
        int highy, highx, lowy, lowx;
        List<GameObject> retList = new List<GameObject>();
        Debug.Log("start : X coord: " + startPos.x + "start : Y coord:" + startPos.y);
        Debug.Log("end : X coord: " + endPos.x + " end : Y coord:" + endPos.y);
        if (startPos.x <= endPos.x)
        {
            lowx = (int)startPos.x;
            highx = (int)endPos.x;
        }
        else
        {
            lowx = (int)endPos.x;
            highx = (int)startPos.x;
        }
        if(startPos.y <= endPos.y)
        {
            lowy = (int)startPos.y;
            highy = (int)endPos.y;
        }
        else
        {
            lowy = (int)endPos.y;
            highy = (int)startPos.y;
        }

        for(int x = (int)lowx; x <= (int)highx; x++ )
        {
            for (int y = (int)lowy; y <= (int)highy; y++)
            {
               
                retList.Add(TilesGrid[x, y].gameObject);
            }


        }
        return retList;




    }
   
}
