using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour {
    [SerializeField]
    private LayerMask clickable;

    private List<GameObject> selectedObjects;
    private Transform target;
    private Vector2 vec3;
    public float speed = 4;
    private Units building;
    // Use this for initialization
    void Start () {
        selectedObjects = new List<GameObject>();
        building = GetComponent<Units>();
        
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

                building = hit.transform.GetComponent<Units>();
                building.setTargeted();
                selectedObjects.Add(hit.transform.gameObject);

            }


        }
        else if (Input.GetMouseButtonDown(0))
        {
            selectedObjects.Clear();

            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
            if (hit)
            {


                building = hit.transform.GetComponent<Units>();
                building.setTargeted();
                selectedObjects.Add(hit.transform.gameObject);
            }


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
	}
  

