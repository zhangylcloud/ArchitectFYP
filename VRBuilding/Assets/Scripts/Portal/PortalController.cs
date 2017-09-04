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

    public int toPortalNum;
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
        Transform renderQuadTrans = transform.Find("RenderQuad");
        stereoRenderer = renderQuadTrans.GetComponent<StereoRenderer>();
        renderQuad.SetActive(false);
        senderQuad.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        hmdPos = hmd.position;	
        if(isEnableFlag == false && (hmdPos - transform.position).magnitude < disThreshold)
        {
            renderQuad.SetActive(true);
            senderQuad.SetActive(true);
            Transform toPortalAnchor = spaceManager.GetToPortalAnchor(toPortalNum);
            stereoRenderer.anchorTransform = toPortalAnchor;
            int toSpaceNum = spaceManager.GetSpaceNum(toPortalNum);
            spaceManager.EnableSpace(toSpaceNum);
            isEnableFlag = true;
        }
        else if(isEnableFlag == true && (hmdPos - transform.position).magnitude > disThreshold){
            renderQuad.SetActive(false);
            senderQuad.SetActive(false);
            int toSpaceNum = spaceManager.GetSpaceNum(toPortalNum);
            spaceManager.DisableSpace(toSpaceNum);
            isEnableFlag = false;
        }
	}
}
