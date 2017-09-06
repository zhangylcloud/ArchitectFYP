using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.StereoRendering;

public class PortalController : MonoBehaviour {
    public Transform hmd;
    private Vector3 hmdPos;
    public GameObject renderQuad;
    public GameObject senderQuad;
    private bool isEnableFlag;
    float dThreshold;
    float angleThreshold;
    

    //private int toPortalNum;
    public int myPortalNum;

    public SpaceManager spaceManager;
    public StereoRenderer stereoRenderer;
	// Use this for initialization
	void Start () {
        isEnableFlag = false;
        dThreshold = 2.0f;
        angleThreshold = 150.0f;
        hmd = GameObject.Find("Camera (eye)").transform;
        hmdPos = hmd.position;

        GameObject sm = GameObject.Find("SpaceManager");
        spaceManager = sm.GetComponent<SpaceManager>();
        //toPortalNum = spaceManager.GetToPortalNum(myPortalNum);
        Transform renderQuadTrans = transform.Find("RenderQuad");
        stereoRenderer = renderQuadTrans.GetComponent<StereoRenderer>();
        renderQuad.SetActive(false);
        senderQuad.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("To portal number " + toPortalNum);
        hmdPos = hmd.position;	
        if(isEnableFlag == false && (hmdPos - transform.position).magnitude < dThreshold /*IfEnable()*/)
        {
            renderQuad.SetActive(true);
            senderQuad.SetActive(true);
            int toSpaceNum = spaceManager.GetSpaceNum(spaceManager.GetToPortalNum(myPortalNum));
            spaceManager.EnableSpace(toSpaceNum);
            Transform toPortalAnchor = spaceManager.GetToPortalAnchor(spaceManager.GetToPortalNum(myPortalNum));
            stereoRenderer.anchorTransform = toPortalAnchor;
            isEnableFlag = true;
        }
        else if(isEnableFlag == true && (hmdPos - transform.position).magnitude > dThreshold /*!IfEnable()*/){
            renderQuad.SetActive(false);
            senderQuad.SetActive(false);
            int toSpaceNum = spaceManager.GetSpaceNum(spaceManager.GetToPortalNum(myPortalNum));
            spaceManager.DisableSpace(toSpaceNum);
            isEnableFlag = false;
        }
	}


    /*bool IfEnable()
    {
        //if outside range
        if((hmd.position- transform.position).magnitude > dThreshold)
        {
            return false;
        }
        Vector3 renderQuadForward = -renderQuad.transform.forward;
        Vector3 renderQuadPosition = renderQuad.transform.position;
        Vector3 playerToRenderQuadVec = hmd.position- renderQuadPosition;

        float cosAngle = Vector3.Dot(playerToRenderQuadVec, renderQuadForward) / (playerToRenderQuadVec.magnitude * renderQuadForward.magnitude);
        float cosCone = Mathf.Cos(angleThreshold * 3.1415f / 360);
        return cosAngle >= cosCone;

    }*/
}
