using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterChange : MonoBehaviour {
    public GameObject playerController;
    public Movement moveController;
    public Transform waterSurfaceTrans;
    public bool isInWaterAreaFlag;
    public float distanceAffected = 50;
    // Use this for initialization
    void Start () {
        playerController = GameObject.Find("[CameraRig]");
        moveController = playerController.transform.Find("Controller (left)").GetComponent<Movement>();
        isInWaterAreaFlag = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if(!isInWaterAreaFlag && (playerController.transform.position - transform.position).magnitude < distanceAffected && playerController.transform.position.y < waterSurfaceTrans.position.y)
        {
            isInWaterAreaFlag = true;
            moveController.speed = 1;
            moveController.jumpController.jumpSpeed = 1;
            moveController.jumpController.gravity = 1;
        }
        else if(isInWaterAreaFlag && (((playerController.transform.position - transform.position).magnitude > distanceAffected) || (playerController.transform.position.y > waterSurfaceTrans.position.y)))
        {
            isInWaterAreaFlag = false;
            moveController.speed = moveController.GetSpeedSet();
            moveController.jumpController.jumpSpeed = moveController.jumpController.GetJumpSpeedSet();
            moveController.jumpController.gravity = moveController.jumpController.GetGravitySet();
        }
	}
}
