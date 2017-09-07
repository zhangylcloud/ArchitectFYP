using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject player;
    public SpaceManager spaceManager;
    public Transform resetAnchorTrans;
    //public Movement movement;
    
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("[CameraRig]");
        spaceManager = GameObject.Find("SpaceManager").GetComponent<SpaceManager>();
    }
    // Update is called once per frame
    
    public void ResetGame()
    {
        GameObject prevSpace = spaceManager.spaces[spaceManager.GetCurrentFace()];
        int prevFaceNum = spaceManager.GetCurrentFace();
        spaceManager.spaces[3].SetActive(true);
        resetAnchorTrans = spaceManager.spaces[3].transform.Find("MainSpaceAnchor").transform;
        player.transform.position = resetAnchorTrans.position;
        player.transform.rotation = Quaternion.identity;
        int toSpaceNum = 3;//Set to the left surface;
        spaceManager.RearrangeFace(prevFaceNum, toSpaceNum);
        spaceManager.SetCurrentFace(toSpaceNum < 7 ? 0 : toSpaceNum);
        prevSpace.SetActive(false);

    }
}
