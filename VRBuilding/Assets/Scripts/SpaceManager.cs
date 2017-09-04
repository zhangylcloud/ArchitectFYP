using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManager : MonoBehaviour {
    private int[] portalLookUpTable = new int[80];
    //given a portal number, find which face on the mainspace it is (0 - 5)
    private int[] portalFaceMatch = new int[80];

    //0: tmp Mainspace, 1-6 mainspace with faces, 7-14: subspaces
    public GameObject[] spaces = new GameObject[15];

    //Directions for use
    public Quaternion[] dirs = new Quaternion[6];

    public GameObject player;

	// Use this for initialization
	void Start () {
        //portal look up table
        portalLookUpTable[0] = 0;
        portalLookUpTable[1] = 41;
        portalLookUpTable[2] = 42;
        portalLookUpTable[3] = 10;
        portalLookUpTable[4] = 44;
        portalLookUpTable[5] = 45;
        portalLookUpTable[6] = 9;
        portalLookUpTable[7] = 47;
        portalLookUpTable[8] = 37;
        portalLookUpTable[9] = 12;
        portalLookUpTable[10] = 3;
        portalLookUpTable[11] = 51;
        portalLookUpTable[12] = 13;
        portalLookUpTable[13] = 24;
        portalLookUpTable[14] = 13;
        portalLookUpTable[15] = 22;
        portalLookUpTable[16] = 12;
        portalLookUpTable[17] = 57;
        portalLookUpTable[18] = 58;
        portalLookUpTable[19] = 20;
        portalLookUpTable[20] = 35;
        portalLookUpTable[21] = 6;
        portalLookUpTable[22] = 62;
        portalLookUpTable[23] = 63;
        portalLookUpTable[24] = 64;
        portalLookUpTable[25] = 15;
        portalLookUpTable[26] = 66;
        portalLookUpTable[27] = 67;
        portalLookUpTable[28] = 68;
        portalLookUpTable[29] = 69;
        portalLookUpTable[30] = 70;
        portalLookUpTable[31] = 16;
        portalLookUpTable[32] = 72;
        portalLookUpTable[33] = 73;
        portalLookUpTable[34] = 19;
        portalLookUpTable[35] = 37;
        portalLookUpTable[36] = 76;
        portalLookUpTable[37] = 26;
        portalLookUpTable[38] = 78;
        portalLookUpTable[39] = 29;
        portalLookUpTable[40] = 25;
        portalLookUpTable[41] = 1;
        portalLookUpTable[42] = 2;
        portalLookUpTable[43] = 0;
        portalLookUpTable[44] = 4;
        portalLookUpTable[45] = 5;
        portalLookUpTable[46] = 0;
        portalLookUpTable[47] = 7;
        portalLookUpTable[48] = 0;
        portalLookUpTable[49] = 0;
        portalLookUpTable[50] = 0;
        portalLookUpTable[51] = 11;
        portalLookUpTable[52] = 0;
        portalLookUpTable[53] = 0;
        portalLookUpTable[54] = 0;
        portalLookUpTable[55] = 0;
        portalLookUpTable[56] = 0;
        portalLookUpTable[57] = 17;
        portalLookUpTable[58] = 18;
        portalLookUpTable[59] = 0;
        portalLookUpTable[60] = 0;
        portalLookUpTable[61] = 0;
        portalLookUpTable[62] = 22;
        portalLookUpTable[63] = 23;
        portalLookUpTable[64] = 24;
        portalLookUpTable[65] = 0;
        portalLookUpTable[66] = 26;
        portalLookUpTable[67] = 27;
        portalLookUpTable[68] = 28;
        portalLookUpTable[69] = 29;
        portalLookUpTable[70] = 30;
        portalLookUpTable[71] = 0;
        portalLookUpTable[72] = 32;
        portalLookUpTable[73] = 33;
        portalLookUpTable[74] = 0;
        portalLookUpTable[75] = 0;
        portalLookUpTable[76] = 36;
        portalLookUpTable[77] = 0;
        portalLookUpTable[78] = 38;




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
