using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Pickup : MonoBehaviour
{

    SteamVR_TrackedObject trackedObj;
    public CharacterController charController;
    SteamVR_Controller.Device device;
    Transform originalParent;
    //public Movement movement;
    //public bool isButtonPressed;
    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        
    }
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        //isButtonPressed = device.GetPress(SteamVR_Controller.ButtonMask.ButtonA);
        //Debug.Log("isButtonPressed" + isButtonPressed);
        //Debug.Log("isTriggerPressed" + device.GetPress(SteamVR_Controller.ButtonMask.Trigger));
    }

    private void OnTriggerStay(Collider other)
    {
       
        if (other.gameObject.layer == LayerMask.NameToLayer("PickUp") && device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            other.attachedRigidbody.isKinematic = true;
            other.attachedRigidbody.useGravity = false;
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
            originalParent = other.gameObject.transform.parent;
            other.gameObject.transform.SetParent(transform);
        }
        if(device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {

            other.gameObject.transform.SetParent(originalParent);
            other.attachedRigidbody.isKinematic = false;
            other.attachedRigidbody.useGravity = true;
            tossObject(other.attachedRigidbody);
        }
        
    }

    void tossObject(Rigidbody rigidbody)
    {
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if(origin != null)
        {
            rigidbody.velocity = origin.TransformVector(device.velocity);
            rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);

        }
        else
        {
            rigidbody.velocity = device.velocity;
            rigidbody.angularVelocity = device.angularVelocity;
        }
    }


}
