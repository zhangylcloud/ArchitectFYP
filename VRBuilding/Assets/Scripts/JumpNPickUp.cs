using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SteamVR_TrackedObject))]
public class JumpNPickUp : MonoBehaviour
{
    public const float jumpSpeedSet = 3;
    public const float gravitySet = 9.8f;

    SteamVR_TrackedObject trackedObj;
    public CharacterController charController;
    //public Movement movement;
    public float jumpSpeed = jumpSpeedSet;
    public float gravity = gravitySet;
    public bool isButtonPressed;
    SteamVR_Controller.Device device;
    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }
    // Use this for initialization
    void Start()
    {
    }
    public float GetJumpSpeedSet()
    {
        return jumpSpeedSet;
    }
    public float GetGravitySet()
    {
        return gravitySet;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        isButtonPressed = device.GetPress(SteamVR_Controller.ButtonMask.ButtonA);
        //Debug.Log("isButtonPressed" + isButtonPressed);
        //Debug.Log("isTriggerPressed" + device.GetPress(SteamVR_Controller.ButtonMask.Trigger));
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PickUp"))
        {
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {

            }
        }

    }
}
