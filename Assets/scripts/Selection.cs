using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour {
    [SerializeField]
    Camera m_camera;
    panelScript panelScript;
    int mask;

    public enum SelectingModes
    {
        units,
        buildings,
        createbuildings
    }

    public SelectingModes selectMode;
    public static Selection me;
    private List<GameObject> selectedObjects;
    private Transform target;
    private Vector2 vec3;
    private Units Units;
    RaycastHit2D hit;


    // Use this for initialization
    void Start () {
        selectedObjects = new List<GameObject>();
        Units = GetComponent<Units>();
        me = this;
        m_camera = Camera.main;
        panelScript = GetComponent<panelScript>();
        mask  = 1024;
        

    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.Log(selectedObjects.Count);
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButtonDown(0))
        {
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f, mask);
            if (hit && hit.transform.gameObject.tag == "Units")
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
            

            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            hit = Physics2D.Raycast(origin, Vector2.zero, 0f, mask);
            if (hit)
            {
                print(hit.transform.gameObject.tag);
                if (hit.transform.gameObject.tag == "Units")
                {
                    m_camera.GetComponent<panelScript>().ShowPanel();
                    selectedObjects.Clear();
                    Units = hit.transform.GetComponent<Units>();
                    Units.setTargeted();
                    m_camera.GetComponent<panelScript>().setName(Units.myName);
                    selectedObjects.Add(hit.transform.gameObject);

                }
            }
           /* else
                m_camera.GetComponent<panelScript>().HidePanel();*/


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
    void getTilesFromCoords(int width, int height)
    {
        width += 2;
        height += 2;
        GameObject tileAtMouse = null;

        Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                     Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
        if (hit)
        {
            tileAtMouse = hit.transform.gameObject;
        }
        TileMaster tm = tileAtMouse.GetComponent<TileMaster>();
        Vector2 tileGridCoords = tm.getGridCoords();

        if (!isSelectionInRange(tileGridCoords, width, height) == true)
        {
            Vector2 startPos = new Vector2(tileGridCoords.x - (width / 2), tileGridCoords.y - (height / 2));
            Vector2 endPos = new Vector2(tileGridCoords.x + (width / 2), tileGridCoords.y + (height / 2));
            
        }

    }

    bool isSelectionInRange(Vector2 center, int width, int height)
    {
        width /= 2;
        height /= 2;
        if ((center.x - width) < 0 || (center.y - height) < 0)
        {
            return false;
        }
        else
            return true;

    }
       

 }
  

