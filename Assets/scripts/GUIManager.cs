using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {


    public static GUIManager me;
    public Texture2D blackbox;
    string[] MenuOptions;
    float originalWidth = Screen.width;
    float originalHeight = Screen.height;
    // Use this for initialization
	void Start () {
        me = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void alterButtons()
    {

    }

}
