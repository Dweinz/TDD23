using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrass : TileMaster {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnSelect()
    {
        Debug.Log(" Tile grass " + this.gameObject.transform.position);

    }
}
