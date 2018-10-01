using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaster : MonoBehaviour {
    float gridX, gridY;
    public bool walkAble;

	// Use this for initialization
	void Start () {
        walkAble = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public virtual void OnSelect()
    {
        Debug.Log(" Tile master " + this.gameObject.transform.position);
        
    }
    public Vector2 getGridCoords()
    {
        return new Vector2(gridX, gridY);
    }
    public void setGridCoords(Vector2 coords)
    {
        gridX = coords.x;
        gridY = coords.y;
    }
    public void setWalkAble(bool walk)
    {
        walkAble = walk;
    }
    public bool isTileWalkAble()
    {
        return walkAble;
    }
}
