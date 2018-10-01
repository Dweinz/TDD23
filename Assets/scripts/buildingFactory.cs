using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingFactory : MonoBehaviour {
    public static buildingFactory me;
    public GameObject[] buildings;
    [SerializeField]
    GameObject selectedBuilding;
	// Use this for initialization
	void Start () {
        me = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public GameObject buildingToBuild()
    {
        return selectedBuilding;
    }
    void OnGUI()
    {
        Debug.Log("bygg?");
    if(Selection.me.selectMode == Selection.SelectingModes.createbuildings)
        {
            int yMod = 0;
            Debug.Log("bygg");  
            foreach(GameObject b in buildings)
            {
                try
                {
                    Buildings buildingScreen = b.GetComponent<Buildings>();
                    Rect pos = new Rect(500, 20 + (20* yMod), 20, 20);
                    if (GUI.Button(pos, b.name))
                    {
                        selectedBuilding = b;
                    }
                    yMod += 1;
                }
                catch
                {
                    Debug.Log("Build missing component");
                }
            }
        }
        

    }

}
