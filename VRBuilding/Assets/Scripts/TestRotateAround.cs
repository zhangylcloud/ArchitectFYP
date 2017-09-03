using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotateAround : MonoBehaviour {
    public Transform pivot;
    public float totalAngleRotated;
	// Use this for initialization
	void Start () {
        totalAngleRotated = 0;	
	}
	
	// Update is called once per frame
	void Update () {
        if(totalAngleRotated < 90)
        {
            transform.RotateAround(pivot.position, pivot.right, 90 * Time.deltaTime);
            totalAngleRotated += 90 * Time.deltaTime;
        }
	}
}
