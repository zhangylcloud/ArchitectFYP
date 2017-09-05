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
    public float disThreshold;

    //private int toPortalNum;
    public int myPortalNum;

    public SpaceManager spaceManager;
    public StereoRenderer stereoRenderer;
	// Use this for initialization
	void Start () {
        isEnableFlag = false;
        disThreshold = 2.0f;
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
        if(isEnableFlag == false && (hmdPos - transform.position).magnitude < disThreshold)
        {
            renderQuad.SetActive(true);
            senderQuad.SetActive(true);
            int toSpaceNum = spaceManager.GetSpaceNum(spaceManager.GetToPortalNum(myPortalNum));
            spaceManager.EnableSpace(toSpaceNum);
            Transform toPortalAnchor = spaceManager.GetToPortalAnchor(spaceManager.GetToPortalNum(myPortalNum));
            stereoRenderer.anchorTransform = toPortalAnchor;
            isEnableFlag = true;
        }
        else if(isEnableFlag == true && (hmdPos - transform.position).magnitude > disThreshold){
            renderQuad.SetActive(false);
            senderQuad.SetActive(false);
            int toSpaceNum = spaceManager.GetSpaceNum(spaceManager.GetToPortalNum(myPortalNum));
            spaceManager.DisableSpace(toSpaceNum);
            isEnableFlag = false;
        }
	}
}
