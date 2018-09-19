using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelScript : MonoBehaviour {

    public GameObject Panel;
    public Text UnitName;
	// Use this for initialization
	void Start () {
        Panel.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update () {
		
	}
    public void HidePanel()
    {
        Panel.gameObject.SetActive(false);
    }
    public void ShowPanel()
    {
        Panel.gameObject.SetActive(true);
    }
    public void setName(string text)
    {

        UnitName.text = text;
    }
}
