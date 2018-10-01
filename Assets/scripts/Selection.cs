using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour {
    [SerializeField]
    Camera m_camera;
    panelScript panelScript;
    int mask;
    public GameObject buildingCursor;

    public enum SelectingModes
    {
        units,
        buildings,
        createbuildings
    }

    public SelectingModes selectMode;
    public static Selection me;
    private List<GameObject> selectedObjects;
    private List<GameObject> selectedTiles;
    private Transform target;
    private Vector2 vec3;
    private Units Units;
    RaycastHit2D hit;


    // Use this for initialization
    void Start () {
        selectedObjects = new List<GameObject>();
        selectedTiles = new List<GameObject>();
        Units = GetComponent<Units>();
        me = this;
        m_camera = Camera.main;
        panelScript = GetComponent<panelScript>();
        mask  = 1024;
        selectMode = SelectingModes.createbuildings;
        

    }

    // Update is called once per frame
    void Update()
    {
        CheckForClick();
        createBuildingOnLeftClick();


        
    }
    void CheckForClick()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButtonDown(0))
        {
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f, mask);
            if (hit && hit.transform.gameObject.tag == "Units")
            {
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
                if (hit.transform.gameObject.tag == "Units")
                {
                    me.selectMode = SelectingModes.createbuildings;
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
        /*
        else if (Input.GetMouseButtonDown(1))
        {
            vec3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach (var item in selectedObjects)
            {
                item.GetComponent<Units>().setTarget(vec3);

            }
        }*/
    }
    void getTilesFromCoords(int width, int height)
    {
        try {
            width += 2;
            height += 2;
            GameObject tileAtMouse = null;
            int mask2 = 1 << 9;

            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            hit = Physics2D.Raycast(origin, Vector2.zero, 0f, mask2);
            if (hit)
            {
                tileAtMouse = hit.transform.gameObject;
            }
            if (tileAtMouse != null)
            {
                TileMaster tm = tileAtMouse.GetComponent<TileMaster>();
                if (tm != null)
                {
                    Vector2 tileGridCoords = tm.getGridCoords();
                    //Debug.Log(tileGridCoords.x + "   " + tileGridCoords.y);


                    if (!isSelectionInRange(tileGridCoords, width, height) == true)
                    {
                        Vector2 startPos = new Vector2(tileGridCoords.x - (width / 2), tileGridCoords.y - (height / 2));
                        Vector2 endPos = new Vector2(tileGridCoords.x + (width / 2), tileGridCoords.y + (height / 2));
                        setSelected(GridClass.me.getTiles(startPos, endPos));

                    }
                }
            }

        }
        catch
        {
            Debug.Log("No TILE ON MOUSE");
        }
        }

    bool isSelectionInRange(Vector2 center, int width, int height)
    {
        width /= 2;
        height /= 2;
        if ((center.x - width) < 0 || (center.y - height) < 0 || (center.x + width) >= GridClass.me.GridDimension.x || (center.y + height) >= GridClass.me.GridDimension.y)
        {
            return false;
        }
        else
            return true;

    }
    void createBuildingOnLeftClick()
    {
        //Debug.Log("create");    
        GameObject SelectedBuilding = buildingFactory.me.buildingToBuild();
        if(SelectedBuilding != null)
        {
            Buildings checkForComponent = SelectedBuilding.GetComponent<Buildings>();
            if(checkForComponent != null)
            {
                getTilesFromCoords(checkForComponent.widthInTiles, checkForComponent.heightInTiles);
                buildingCursor.GetComponent<SpriteRenderer>().sprite = checkForComponent.buildingSprite;
                buildingCursor.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                Color cursorColor = new Color(1, 0, 0, 0.6f);
                buildingCursor.GetComponent<SpriteRenderer>().color = cursorColor;
                if(canIBuildHere())
                {
                    buildingCursor.GetComponent<SpriteRenderer>().color = cursorColor;
                }
                else
                {
                    cursorColor = new Color(1, 0, 0, 0.5f);
                    buildingCursor.GetComponent<SpriteRenderer>().color = cursorColor;
                }





            }








        }


    }
    void setSelected(List<GameObject> listAdd)
    {
        for (int i = 0; i < listAdd.Count; i++)
        {
            selectedTiles.Add(listAdd[i]);

        }
    }
    public bool canIBuildHere()
    {
        foreach(GameObject tile in selectedTiles)
        {
            TileMaster tm = tile.GetComponent<TileMaster>();
            if(tm.isTileWalkAble() == false)
            {
                return false;
            }

        }

        return true;

    }

 }
  

