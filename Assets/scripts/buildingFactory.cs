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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnGUI()
    {
    if(Selection.me.selectMode == Selection.SelectingModes.createbuildings)
        {
            int yMod = 0;
            foreach(GameObject b in buildings)
            {
                try
                {
                    Buildings buildingScreen = b.GetComponent<Buildings>();
                    Rect pos = new Rect(50, 50 + (50 * yMod), 100, 50);
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
