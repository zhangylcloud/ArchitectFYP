using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour {
    public float rotateSpeed;
    public Transform point1;
    public Transform point2;
    private Vector3 axis;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        axis = point2.position - point1.position;
        transform.RotateAround(point1.position, axis, rotateSpeed * Time.deltaTime);
	}
}
