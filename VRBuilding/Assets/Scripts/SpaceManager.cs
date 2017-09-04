using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManager : MonoBehaviour {
    private int[] portalLookUpTable = new int[50];
    //given a portal number, find which face on the mainspace it is (0 - 5)
    private int[] portalFaceMatch = new int[50];

    //0: tmp Mainspace, 1-6 mainspace with faces, 7-14: subspaces
    public GameObject[] spaces = new GameObject[15];

    //Directions for use
    public Quaternion[] dirs = new Quaternion[6];

    public GameObject player;

	// Use this for initialization
	void Start () {
        //portal look up table
        portalLookUpTable[0] = 0;
        portalLookUpTable[1] = 0;
        portalLookUpTable[2] = 0;
        portalLookUpTable[3] = 0;
        portalLookUpTable[4] = 0;
        portalLookUpTable[5] = 0;
        portalLookUpTable[6] = 0;
        portalLookUpTable[7] = 0;
        portalLookUpTable[8] = 0;
        portalLookUpTable[9] = 0;
        portalLookUpTable[10] = 0;
        portalLookUpTable[11] = 0;
        portalLookUpTable[12] = 0;
        portalLookUpTable[13] = 0;
        portalLookUpTable[14] = 0;
        portalLookUpTable[15] = 0;
        portalLookUpTable[16] = 0;
        portalLookUpTable[17] = 0;
        portalLookUpTable[18] = 0;
        portalLookUpTable[19] = 0;
        portalLookUpTable[20] = 0;
        portalLookUpTable[21] = 0;
        portalLookUpTable[22] = 0;
        portalLookUpTable[23] = 0;
        portalLookUpTable[24] = 0;
        portalLookUpTable[25] = 0;
        portalLookUpTable[26] = 0;
        portalLookUpTable[27] = 0;
        portalLookUpTable[28] = 0;
        portalLookUpTable[29] = 0;
        portalLookUpTable[30] = 0;
        portalLookUpTable[31] = 0;
        portalLookUpTable[32] = 0;
        portalLookUpTable[33] = 0;
        portalLookUpTable[34] = 0;
        portalLookUpTable[35] = 0;
        portalLookUpTable[36] = 0;
        portalLookUpTable[37] = 0;
        portalLookUpTable[38] = 0;
        portalLookUpTable[39] = 0;
        portalLookUpTable[40] = 0;
        portalLookUpTable[41] = 0;
        portalLookUpTable[42] = 0;
        portalLookUpTable[43] = 0;
        portalLookUpTable[44] = 0;
        portalLookUpTable[45] = 0;
        portalLookUpTable[46] = 0;
        portalLookUpTable[47] = 0;
        portalLookUpTable[48] = 0;
        portalLookUpTable[49] = 0;


        //portal face match
        portalFaceMatch[0] = 0;
        portalFaceMatch[1] = 0;
        portalFaceMatch[2] = 0;
        portalFaceMatch[3] = 0;
        portalFaceMatch[4] = 0;
        portalFaceMatch[5] = 0;
        portalFaceMatch[6] = 0;
        portalFaceMatch[7] = 0;
        portalFaceMatch[8] = 0;
        portalFaceMatch[9] = 0;
        portalFaceMatch[10] = 0;
        portalFaceMatch[11] = 0;
        portalFaceMatch[12] = 0;
        portalFaceMatch[13] = 0;
        portalFaceMatch[14] = 0;
        portalFaceMatch[15] = 0;
        portalFaceMatch[16] = 0;
        portalFaceMatch[17] = 0;
        portalFaceMatch[18] = 0;
        portalFaceMatch[19] = 0;
        portalFaceMatch[20] = 0;
        portalFaceMatch[21] = 0;
        portalFaceMatch[22] = 0;
        portalFaceMatch[23] = 0;
        portalFaceMatch[24] = 0;
        portalFaceMatch[25] = 0;
        portalFaceMatch[26] = 0;
        portalFaceMatch[27] = 0;
        portalFaceMatch[28] = 0;
        portalFaceMatch[29] = 0;
        portalFaceMatch[30] = 0;
        portalFaceMatch[31] = 0;
        portalFaceMatch[32] = 0;
        portalFaceMatch[33] = 0;
        portalFaceMatch[34] = 0;
        portalFaceMatch[35] = 0;
        portalFaceMatch[36] = 0;
        portalFaceMatch[37] = 0;
        portalFaceMatch[38] = 0;
        portalFaceMatch[39] = 0;
        portalFaceMatch[40] = 0;
        portalFaceMatch[41] = 0;
        portalFaceMatch[42] = 0;
        portalFaceMatch[43] = 0;
        portalFaceMatch[44] = 0;
        portalFaceMatch[45] = 0;
        portalFaceMatch[46] = 0;
        portalFaceMatch[47] = 0;
        portalFaceMatch[48] = 0;
        portalFaceMatch[49] = 0;

        for(int i = 1; i < 15; ++i)
        {
            spaces[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //Find the to portal number given this portal number
    public int GetToPortalNum(int myPortalNum)
    {
        return portalLookUpTable[myPortalNum];
    }
    //return the portal anchor transform on correct face on correct space given the portal number need to go
    public Transform GetToPortalAnchor(int toPortalNum)
    {
        int face = portalFaceMatch[toPortalNum];
        GameObject toSpace = spaces[face];
        PortalCollector portalCollector = toSpace.GetComponent<PortalCollector>();
        Transform targetBuddyTrans = portalCollector.portals[toPortalNum].transform.Find("SenderQuad").Find("BuddyAnchor");
        return targetBuddyTrans;
    }
    //given portalnumber get which space the portal should be in
    public int GetSpaceNum(int portalNum)
    {
        return portalFaceMatch[portalNum];
    }
    public void EnableSpace(int spaceNum)
    {
        spaces[spaceNum].SetActive(true);
    }
    public void DisableSpace(int spaceNum)
    {
        //Never disable current space
        if(spaces[spaceNum] != player.GetComponent<CharCtrlFollow>().currentSpace)
        {
            spaces[spaceNum].SetActive(false);
        }
        
    }
    //rearrange faces (spaces array) to ensure at every moment spaces are in correct position in the array
    public void rearrangeFace(int toFaceNum)
    {
        if(toFaceNum < 7)
        {
            GameObject tmp = spaces[0];
            spaces[0] = spaces[toFaceNum];
            spaces[toFaceNum] = tmp;
            //spaces[toFaceNum].transform.rotation = dirs[toFaceNum];
        }

    }
}
