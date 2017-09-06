using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleShifter : MonoBehaviour {
    public GameObject bottle1;
    public GameObject bottle2;
    public bool isFull;
	// Use this for initialization
	void Start () {
        isFull = false;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShiftBottle()
    {
        bottle1.SetActive(false);
        bottle2.SetActive(true);
    }

    

    private void FixedUpdate()
    {
        if(Physics.Raycast(transform.position, new Vector3(0, -1, 0), 0.2f, 1 << LayerMask.NameToLayer("River")))
        {
            ShiftBottle();
            isFull = true;
        }
        RaycastHit hitObj;
        if (isFull && Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0, 1, 0)),out hitObj, 2.0f, 1 << LayerMask.NameToLayer("Flower")))
        {
            hitObj.collider.gameObject.GetComponent<GrassFlowerShifter>().Shift();
        }
    }
}
