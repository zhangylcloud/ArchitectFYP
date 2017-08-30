using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Move : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = 0;
    public float facingDirChangeSen = 9.0f;
    public CharacterController charController;
    // Use this for initialization
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //OVRInput.Update();
        //SecondaryThumbStick is used to control direction
        //ector2 sThumbStickVec = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        //transform.Rotate(0, sThumbStickVec.x, 0);

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        //Primary ThumbStick is used to control movement
        /*Vector2 pThumbStickVec = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 movement = new Vector3(pThumbStickVec.x, 0, pThumbStickVec.y);*/
        /*Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);*/
        transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
    }
}
