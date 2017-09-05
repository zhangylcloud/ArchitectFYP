using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Jump : MonoBehaviour {
    SteamVR_TrackedObject trackedObj;
    public CharacterController charController;
    //public Movement movement;
    public float jumpSpeed = 10;
    public float gravity = 9.8f;
    public bool isButtonPressed;
    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        isButtonPressed = device.GetPress(SteamVR_Controller.ButtonMask.ButtonA);
        //Debug.Log("isButtonPressed" + isButtonPressed);
        
    }
}
