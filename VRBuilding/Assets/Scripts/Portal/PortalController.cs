using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.StereoRendering;

public class PortalController : MonoBehaviour {
    public Transform hmd;
    private Vector3 hmdPos;
    public GameObject RenderQuad;
    public GameObject SenderQuad;
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
        GameObject sm = GameObject.Find("SpaceManager");
        spaceManager = sm.GetComponent<SpaceManager>();
        Transform renderQuadTrans = transform.Find("RenderQuad");
        stereoRenderer = renderQuadTrans.GetComponent<StereoRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        hmdPos = hmd.position;	
        if(isEnableFlag == false && (hmdPos - transform.position).magnitude < disThreshold)
        {
            RenderQuad.SetActive(true);
            SenderQuad.SetActive(true);
            Transform toPortalAnchor = spaceManager.GetToPortalAnchor(toPortalNum);
            stereoRenderer.anchorTransform = toPortalAnchor;
            int toSpaceNum = spaceManager.GetSpaceNum(toPortalNum);
            spaceManager.EnableSpace(toSpaceNum);
        }
        else if(isEnableFlag == true && (hmdPos - transform.position).magnitude > disThreshold){
            RenderQuad.SetActive(false);
            SenderQuad.SetActive(false);
            int toSpaceNum = spaceManager.GetSpaceNum(toPortalNum);
            spaceManager.DisableSpace(toSpaceNum);
        }
	}
}
