using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItagged : MonoBehaviour {
    public GameObject g;
    panelScript panelScript;
    Camera m_camera;
    // Use this for initialization
    void Start () {
        panelScript = GetComponent<panelScript>();
        m_camera = Camera.main;


    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_camera.GetComponent<panelScript>().ShowPanel();
    }
}
