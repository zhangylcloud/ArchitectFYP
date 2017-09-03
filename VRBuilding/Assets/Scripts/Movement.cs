using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Movement : MonoBehaviour
{
    public Transform charModelTrans;
    public float speed = 1.0f;
    public float gravity = 9.8f;
    float gravitySpeed = 0;
    public CharacterController charController;
    public GameObject hmdObj;

    private float totalRotatedAngle;
    private bool isRotating;
    private float totalTransitionDistance;
    private bool isTransition;//After rotation, move the character controller even further away to avoid trigger rotation again
    private Vector3 curRotatePivot;
    private Vector3 curPivotPos;
    private Vector3 curForwardDir;
    private Vector3 hmdLastFramePos;


    public Transform currentSpace;

    SteamVR_TrackedObject trackedObj;
    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Use this for initialization
    void Start()
    {
        totalRotatedAngle = 0;
        gravitySpeed = 0;
        isRotating = false;
        isTransition = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 pointToCenter = ball.position - (charModelTrans.position + charController.center);

        

        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        Vector2 moveVec = device.GetAxis();
        Vector3 moveVec3D = new Vector3(speed * moveVec.x, 0, speed * moveVec.y);
        moveVec3D = Vector3.ClampMagnitude(moveVec3D, speed);
        moveVec3D = transform.TransformDirection(moveVec3D);//Touchpad movement vector in global space(need to remove normal component)
        Vector3 vecInNormal = Vector3.Dot(moveVec3D, charModelTrans.up) * charModelTrans.up;
        //moveVec after removed normal vector
        Vector3 moveVecWONormal = moveVec3D - vecInNormal;
        //Apply gravity
        /*if (!charController.isGrounded)
        {
            gravitySpeed += gravity;
        }
        else
        {
            gravitySpeed = 0;
        }*/
        


        //Test if at corner
        RaycastHit hitObj;
        if(!isRotating && !isTransition && Physics.Raycast(hmdObj.transform.position, new Vector3(0, -1, 0), out hitObj, 1.0f, 1 << LayerMask.NameToLayer("Turning1"))){
            Debug.DrawLine(hitObj.point, hitObj.point + new Vector3(0, 1, 0), Color.red, 1.0f);
            Transform pivot1 = hitObj.collider.transform.Find("Pivot1");
            Transform pivot2 = hitObj.collider.transform.Find("Pivot2");
            curPivotPos = pivot1.position;
            Vector3 upDir = charModelTrans.up;
            Vector3 forwardBackwardDir = Vector3.Cross(pivot2.position - pivot1.position, upDir);
            Vector3 forwardDir;
            if(moveVecWONormal.magnitude != 0)
            {
                forwardDir = Vector3.Dot(moveVecWONormal, forwardBackwardDir) * forwardBackwardDir;
            }
            else
            {
                forwardDir = Vector3.Dot(hmdObj.transform.position - hmdLastFramePos, forwardBackwardDir) * forwardBackwardDir;
            }
            
            curForwardDir = forwardDir;
            Vector3 rotatePivot = Vector3.Cross(forwardDir, upDir);
            isRotating = true;
            curRotatePivot = rotatePivot;
        }
        else if (!isRotating && !isTransition && Physics.Raycast(hmdObj.transform.position, new Vector3(0, -1, 0), out hitObj, 1.0f, 1 << LayerMask.NameToLayer("Turning2")))
        {
            Debug.DrawLine(hitObj.point, hitObj.point + new Vector3(0, 1, 0), Color.red, 1.0f);
            Transform pivot1 = hitObj.collider.transform.Find("Pivot1");
            Transform pivot2 = hitObj.collider.transform.Find("Pivot2");
            curPivotPos = pivot1.position;
            Vector3 upDir = charModelTrans.up;
            Vector3 forwardBackwardDir = Vector3.Cross(pivot2.position - pivot1.position, upDir);
            Vector3 forwardDir;
            if (moveVecWONormal.magnitude != 0)
            {
                forwardDir = Vector3.Dot(moveVecWONormal, forwardBackwardDir) * forwardBackwardDir;
            }
            else
            {
                forwardDir = Vector3.Dot(hmdObj.transform.position - hmdLastFramePos, forwardBackwardDir) * forwardBackwardDir;
            }

            curForwardDir = forwardDir;
            Vector3 rotatePivot = Vector3.Cross(forwardDir, upDir);
            isRotating = true;
            curRotatePivot = - rotatePivot;
        }
        else if (isRotating)
        {
            if(totalRotatedAngle < 90)
            {
                currentSpace.RotateAround(curPivotPos, curRotatePivot, 30 * Time.deltaTime);
                totalRotatedAngle += 30 * Time.deltaTime;
            }
            else
            {
                isRotating = false;
                totalRotatedAngle = 0;
                isTransition = true;
            }
        }
        else if (isTransition)
        {
            if(totalTransitionDistance < 0.5)
            {
                charController.Move(curForwardDir.normalized * Time.deltaTime);
                totalTransitionDistance += Time.deltaTime;
            }
            else
            {
                totalTransitionDistance = 0;
                isTransition = false;
            }
        }
        else
        {
            Vector3 gravityVec = new Vector3(0, -gravity, 0);
            gravityVec = charModelTrans.TransformDirection(gravityVec);

            moveVecWONormal += gravityVec;
            moveVecWONormal *= Time.deltaTime;
            charController.Move(moveVecWONormal);
        }

        hmdLastFramePos = hmdObj.transform.position;
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
