using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject player;
    public SpaceManager spaceManager;
    public Transform resetAnchorTrans;
    private int[] levelArray = new int[9];
    private int currentJumpIndex;
    //public Movement movement;
    
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("[CameraRig]");
        spaceManager = GameObject.Find("SpaceManager").GetComponent<SpaceManager>();
        currentJumpIndex = 0;
        levelArray[0] = 7;
        levelArray[1] = 8;
        levelArray[2] = 9;
        levelArray[3] = 10;
        levelArray[4] = 11;
        levelArray[5] = 12;
        levelArray[6] = 13;
        levelArray[7] = 14;
        levelArray[8] = 3;
    }
    // Update is called once per frame
    
    public void ResetGame()
    {
        GameObject prevSpace = spaceManager.spaces[spaceManager.GetCurrentFace()];
        int prevFaceNum = spaceManager.GetCurrentFace();
        spaceManager.spaces[3].SetActive(true);
        resetAnchorTrans = spaceManager.spaces[3].transform.Find("SpaceAnchor").transform;
        player.transform.position = resetAnchorTrans.position;
        player.transform.rotation = Quaternion.identity;
        int toSpaceNum = 3;//Set to the left surface;
        spaceManager.RearrangeFace(prevFaceNum, toSpaceNum);
        spaceManager.SetCurrentFace(toSpaceNum < 7 ? 0 : toSpaceNum);
        prevSpace.SetActive(false);

    }

    public void JumpLevel()
    {
        int nextSpaceFace = levelArray[currentJumpIndex];
        GameObject prevSpace = spaceManager.spaces[spaceManager.GetCurrentFace()];
        int prevFaceNum = spaceManager.GetCurrentFace();
        spaceManager.spaces[nextSpaceFace].SetActive(true);
        resetAnchorTrans = spaceManager.spaces[nextSpaceFace].transform.Find("SpaceAnchor").transform;
        player.transform.position = resetAnchorTrans.position;
        player.transform.rotation = Quaternion.identity;
        int toSpaceNum = nextSpaceFace;//Set to the left surface;
        spaceManager.RearrangeFace(prevFaceNum, toSpaceNum);
        spaceManager.SetCurrentFace(toSpaceNum < 7 ? 0 : toSpaceNum);
        prevSpace.SetActive(false);
        currentJumpIndex++;
        if(currentJumpIndex > 8)
        {
            currentJumpIndex = 0;
        }
    }
}
