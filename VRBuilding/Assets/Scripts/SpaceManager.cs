using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManager : MonoBehaviour {
    private int[] portalLookUpTable = new int[80];
    //given a portal number, find which face on the mainspace it is (0 - 5)
    private int[] portalFaceMatch = new int[80];

    //0: tmp Mainspace, 1-6 mainspace with faces, 7-13: subspaces 14-19: multidir subspace(use 6 face, like main space)
    public GameObject[] spaces = new GameObject[20];

    //Directions for use
    public Quaternion[] rotations = new Quaternion[6];

    public GameObject player;
    public int currentFace;

    public Material[] skyboxes = new Material[6];

    //public GameObject tmpPlayer;//for rollercoaster

	// Use this for initialization
	void Start () {
        currentFace = 0;//initially, player at face 0 (temp face)
        //6 directions in use
        rotations[0] = new Quaternion(0, 0, 0, 1);//up
        rotations[1] = new Quaternion(0, 0, 1, 0);//down
        rotations[2] = new Quaternion(0.7f, 0, 0, 0.7f);//left
        rotations[3] = new Quaternion(-0.7f, 0, 0, 0.7f);//right
        rotations[4] = new Quaternion(0, 0, -0.7f, 0.7f);//front
        rotations[5] = new Quaternion(0, 0, 0.7f, 0.7f);//back


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
        portalLookUpTable[61] = 3;
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
        portalFaceMatch[1] = 3;
        portalFaceMatch[2] = 3;
        portalFaceMatch[3] = 5;
        portalFaceMatch[4] = 1;
        portalFaceMatch[5] = 3;
        portalFaceMatch[6] = 3;
        portalFaceMatch[7] = 5;
        portalFaceMatch[8] = 5;
        portalFaceMatch[9] = 2;
        portalFaceMatch[10] = 5;
        portalFaceMatch[11] = 2;
        portalFaceMatch[12] = 6;
        portalFaceMatch[13] = 3;
        portalFaceMatch[14] = 2;
        portalFaceMatch[15] = 2;
        portalFaceMatch[16] = 2;
        portalFaceMatch[17] = 2;
        portalFaceMatch[18] = 5;
        portalFaceMatch[19] = 4;
        portalFaceMatch[20] = 1;
        portalFaceMatch[21] = 5;
        portalFaceMatch[22] = 5;
        portalFaceMatch[23] = 5;
        portalFaceMatch[24] = 6;
        portalFaceMatch[25] = 5;
        portalFaceMatch[26] = 1;
        portalFaceMatch[27] = 1;
        portalFaceMatch[28] = 1;
        portalFaceMatch[29] = 3;
        portalFaceMatch[30] = 3;
        portalFaceMatch[31] = 5;
        portalFaceMatch[32] = 5;
        portalFaceMatch[33] = 3;
        portalFaceMatch[34] = 5;
        portalFaceMatch[35] = 6;
        portalFaceMatch[36] = 2;
        portalFaceMatch[37] = 5;
        portalFaceMatch[38] = 3;
        portalFaceMatch[39] = 3;
        portalFaceMatch[40] = 2;
        portalFaceMatch[41] = 12;
        portalFaceMatch[42] = 7;
        portalFaceMatch[43] = 0;
        portalFaceMatch[44] = 10;
        portalFaceMatch[45] = 11;
        portalFaceMatch[46] = 0;
        portalFaceMatch[47] = 10;
        portalFaceMatch[48] = 0;
        portalFaceMatch[49] = 0;
        portalFaceMatch[50] = 0;
        portalFaceMatch[51] = 13;
        portalFaceMatch[52] = 0;
        portalFaceMatch[53] = 0;
        portalFaceMatch[54] = 0;
        portalFaceMatch[55] = 0;
        portalFaceMatch[56] = 0;
        portalFaceMatch[57] = 7;
        portalFaceMatch[58] = 9;
        portalFaceMatch[59] = 0;
        portalFaceMatch[60] = 0;
        portalFaceMatch[61] = 5;
        portalFaceMatch[62] = 9;
        portalFaceMatch[63] = 14;
        portalFaceMatch[64] = 12;
        portalFaceMatch[65] = 0;
        portalFaceMatch[66] = 15;
        portalFaceMatch[67] = 8;
        portalFaceMatch[68] = 12;
        portalFaceMatch[69] = 13;
        portalFaceMatch[70] = 8;
        portalFaceMatch[71] = 0;
        portalFaceMatch[72] = 11;
        portalFaceMatch[73] = 9;
        portalFaceMatch[74] = 0;
        portalFaceMatch[75] = 0;
        portalFaceMatch[76] = 19;
        portalFaceMatch[77] = 0;
        portalFaceMatch[78] = 18;

        for(int i = 1; i <= 6; ++i)
        {
            spaces[i].transform.rotation = rotations[i - 1];
        }

        for(int i = 14; i <= 19; ++i)
        {
            spaces[i].transform.rotation = rotations[i - 14];
        }
        for (int i = 1; i < 20; ++i)
        {
            spaces[i].SetActive(false);
        }
        //spaces[11].SetActive(true);

    }
	
    void ResetSpaces()
    {
        currentFace = 0;
        for (int i = 1; i <= 6; ++i)
        {
            spaces[i].transform.rotation = rotations[i - 1];
        }

        for (int i = 14; i <= 19; ++i)
        {
            spaces[i].transform.rotation = rotations[i - 14];
        }
        for (int i = 1; i < 20; ++i)
        {
            spaces[i].SetActive(false);
        }
        //spaces[1].transform.rotation
    }
	// Update is called once per frame
	void Update () {
        
		if(currentFace <= 6 && RenderSettings.skybox != skyboxes[1])
        {
            RenderSettings.skybox = skyboxes[2];
        }
        else if(currentFace == 7 && RenderSettings.skybox != skyboxes[0])
        {
            RenderSettings.skybox = skyboxes[0];
        }
        else if(currentFace == 9 && RenderSettings.skybox != skyboxes[2])
        {
            RenderSettings.skybox = skyboxes[2];
        }
        else if(currentFace == 10 && RenderSettings.skybox != skyboxes[3])
        {
            RenderSettings.skybox = skyboxes[3];
        }
        else if(currentFace == 11 && RenderSettings.skybox != skyboxes[4])
        {
            RenderSettings.skybox = skyboxes[4];
        }
        else if(currentFace == 12 && RenderSettings.skybox != skyboxes[5])
        {
            RenderSettings.skybox = skyboxes[5];
        }
        else if(currentFace == 13 && RenderSettings.skybox != skyboxes[3])
        {
            RenderSettings.skybox = skyboxes[3];
        }
        else if(currentFace >= 14 && currentFace <= 19 && RenderSettings.skybox != skyboxes[1])
        {
            RenderSettings.skybox = skyboxes[1];
        }
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
        /*if(spaces[spaceNum] != player.GetComponent<CharCtrlFollow>().currentSpace)
        {
            spaces[spaceNum].SetActive(false);
        }*/
        if (spaceNum != currentFace)
        {
            spaces[spaceNum].SetActive(false);
        }

    }
    //rearrange faces (spaces array) to ensure at every moment spaces are in correct position in the array
    public void RearrangeFace(int fromFaceNum, int toFaceNum)
    {
        if(toFaceNum < 7)
        {
            GameObject tmp = spaces[0];
            spaces[0] = spaces[toFaceNum];
            spaces[toFaceNum] = tmp;
            //make the rotation of the previous standing space facing in the correct direction, for future use
            spaces[toFaceNum].transform.rotation = rotations[toFaceNum - 1];
        }
        if(fromFaceNum >= 14 && fromFaceNum <= 19)//if jump from hanging garden, need to reset the rotation of it.
        {
            spaces[fromFaceNum].transform.rotation = rotations[fromFaceNum - 14];
        }

    }
    public int GetCurrentFace()
    {
        return currentFace;
    }
    public void SetCurrentFace(int faceNum)
    {
        currentFace = faceNum;
    }
}
