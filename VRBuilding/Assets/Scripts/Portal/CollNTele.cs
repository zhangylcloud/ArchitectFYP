//========= Copyright 2016, HTC Corporation. All rights reserved. ===========

using UnityEngine;
using HTC.UnityPlugin.StereoRendering;

public class CollNTele : MonoBehaviour
{
    public Collider playerCollider;

    public GameObject hmdRig;
    public GameObject hmdEye;
    public StereoRenderer stereoRenderer;

    private float prevDot = 0;
    private bool playerOverlapping = false;

    public CharCtrlFollow playerControl;
    public SpaceManager spaceManager;
    public int myPortalNum;
    void Start()
    {
        playerCollider = GameObject.Find("PlayerCollider").GetComponent<Collider>();
        hmdRig = GameObject.Find("[CameraRig]");
        hmdEye = GameObject.Find("Camera (eye)");
        playerControl = hmdRig.GetComponent<CharCtrlFollow>();
        spaceManager = GameObject.Find("SpaceManager").GetComponent<SpaceManager>();
        myPortalNum = transform.parent.GetComponent<PortalController>().myPortalNum;
    }

    private void Update()
    {
        if (playerOverlapping)
        {
            var currentDot = Vector3.Dot(transform.forward, playerCollider.transform.position - transform.position);

            if (currentDot > 0)  // only transport the player once he's moved across plane
            {
                GameObject prevSpace = playerControl.currentSpace;
                teleport();
                //after teleport, disable the space jump from
                spaceManager.rearrangeFace(spaceManager.GetSpaceNum(spaceManager.GetToPortalNum(myPortalNum)));
                prevSpace.SetActive(false);
                playerOverlapping = false;
            }

            prevDot = currentDot;
        }
    }
    private void teleport()
    {
        stereoRenderer.shouldRender = false;

        // adjust rotation
        Quaternion rotEntryToExit = stereoRenderer.anchorRot * Quaternion.Inverse(stereoRenderer.canvasOriginRot);
        hmdRig.transform.rotation = rotEntryToExit * hmdRig.transform.rotation;

        // adjust position
        Vector3 posDiff = new Vector3(stereoRenderer.stereoCameraHead.transform.position.x - hmdEye.transform.position.x,
                                      stereoRenderer.stereoCameraHead.transform.position.y - hmdEye.transform.position.y,
                                      stereoRenderer.stereoCameraHead.transform.position.z - hmdEye.transform.position.z);
        Vector3 camRigTargetPos = hmdRig.transform.position + posDiff;

        // assign the target position to camera rig
        hmdRig.transform.position = camRigTargetPos;

        stereoRenderer.shouldRender = true;
    }


    /////////////////////////////////////////////////////////////////////////////////

    void OnTriggerEnter(Collider other)
    {
        // if hmd has collided with portal door
        if (other == playerCollider /*&& currentDot < 0*/)
        {
            playerOverlapping = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other == playerCollider)
        {
            playerOverlapping = false;
        }
    }
}
