using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour {
    [SerializeField]
    private LayerMask clickable;
    Camera m_camera;
    panelScript panelScript;
    private List<GameObject> selectedObjects;
    private Transform target;
    private Vector2 vec3;
    public float speed = 4;
    private Units Units;
    // Use this for initialization
    void Start () {
        selectedObjects = new List<GameObject>();
        Units = GetComponent<Units>();
        m_camera = Camera.main;
        panelScript = GetComponent<panelScript>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(selectedObjects.Count);
        float step = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButtonDown(0))
        {
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
            if (hit)
            {
                print(hit.transform.gameObject.tag);
                //vec3 = hit.transform.position;

                Units = hit.transform.GetComponent<Units>();
                Units.setTargeted();
                selectedObjects.Add(hit.transform.gameObject);
                m_camera.GetComponent<panelScript>().ShowPanel();

            }
            else
                m_camera.GetComponent<panelScript>().HidePanel();



        }
        else if (Input.GetMouseButtonDown(0))
        {
            selectedObjects.Clear();

            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
            if (hit)
            {

                m_camera.GetComponent<panelScript>().ShowPanel();

                Units = hit.transform.GetComponent<Units>();
                Units.setTargeted();
                m_camera.GetComponent<panelScript>().setName(Units.myName);
                selectedObjects.Add(hit.transform.gameObject);
            }
            else
                m_camera.GetComponent<panelScript>().HidePanel();


        }

        else if (Input.GetMouseButtonDown(1))
        {
            vec3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach (var item in selectedObjects)
            {
                item.GetComponent<Units>().setTarget(vec3);

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Canvas")
        {
            m_camera.GetComponent<panelScript>().ShowPanel();
        }
    }
}
  

