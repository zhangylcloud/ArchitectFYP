using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour {
    public int distanceAffected;
    public GameObject playerController;
    public Jump jumpController;
    private bool isInAreaFlag;
	// Use this for initialization
	void Start () {
        distanceAffected = 100;
        playerController = GameObject.Find("[CameraRig]");
        jumpController = playerController.transform.Find("Controller (right)").GetComponent<Jump>();
        isInAreaFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(!isInAreaFlag && (playerController.transform.position - transform.position).magnitude < distanceAffected)
        {
            isInAreaFlag = true;
            jumpController.gravity = 1;
        }
        else if(isInAreaFlag && (playerController.transform.position - transform.position).magnitude > distanceAffected)
        {
            isInAreaFlag = false;
            jumpController.gravity = jumpController.GetGravitySet();
        }
	}
}
