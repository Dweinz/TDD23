using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {
    public List<GameObject> Units;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void addUnit(GameObject g)
    {
        Units.Add(g);
    }
    public void removeUnit(GameObject g)
    {
        Units.Remove(g);
    }
}
