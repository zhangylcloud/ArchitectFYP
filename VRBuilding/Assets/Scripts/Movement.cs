using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Movement : MonoBehaviour
{
    public Transform charModelTrans;
    public float speed = 6.0f;
    public float gravity = 9.8f;
    public float facingDirChangeSen = 9.0f;
    public CharacterController charController;
    //public bool isRotationEnabled;
    //public bool isTranslationEnabled;


    SteamVR_TrackedObject trackedObj;
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
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        Vector2 moveVec = device.GetAxis();
        //Debug.Log("moveVec is " + moveVec);
        Vector3 moveVec3D = new Vector3(moveVec.x, 0, moveVec.y);
        moveVec3D = Vector3.ClampMagnitude(moveVec3D, speed);
        moveVec3D = transform.TransformDirection(moveVec3D);
        Vector3 gravityVec = new Vector3(0, -9.8f, 0);
        gravityVec = charModelTrans.TransformDirection(gravityVec);
        Debug.Log("moveVec3D is " + moveVec3D);
        Debug.Log("gravityVec is " + gravityVec);
        moveVec3D += gravityVec;
        Debug.Log("moveVec3D after applying gravity is " + moveVec3D);
        moveVec3D *= Time.deltaTime;
        charController.Move(moveVec3D);
            //Debug.Log("Yes, Move vec is " + moveVec3D);
        //OVRInput.Update();
        //SecondaryThumbStick is used to control direction
        //ector2 sThumbStickVec = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        //transform.Rotate(0, sThumbStickVec.x, 0);

        //float deltaX = Input.GetAxis("Horizontal") * speed;
        //float deltaZ = Input.GetAxis("Vertical") * speed;
        //Primary ThumbStick is used to control movement
        /*Vector2 pThumbStickVec = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 movement = new Vector3(pThumbStickVec.x, 0, pThumbStickVec.y);*/
        /*Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);*/
        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
    }
}
