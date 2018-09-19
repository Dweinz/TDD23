using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Units : MonoBehaviour {
    private bool targeted;
    public float speed = 1;
    private Vector2 target;
    public string myName;
    // Use this for initialization
	void Start () {
        targeted = false;
        myName = "worker";
        target = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        if(targeted)
        {
            moveMe(step);
        }
    }

    public void setTarget(Vector2 vector2)
    {
        target = vector2;
    }
    public void setTargeted()
    {
        targeted = true;
    }
    public void moveMe(float step)
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, target, step);
    }
   
}
