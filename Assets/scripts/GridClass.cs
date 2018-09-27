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
                Vector3 posToCreatetile = new Vector3(x-12, y-8, 0);
                GameObject recentTile = (GameObject)Instantiate(prefabTile1, posToCreatetile, Quaternion.Euler(0, 0, 0));
                recentTile.GetComponent<TileMaster>().setGridCoords(new Vector2(x-12, y-8));
                recentTile.transform.parent = this.gameObject.transform;
                TilesGrid[x, y] = recentTile.GetComponent<TileGrass>();

            }
        }
    }
   
}
