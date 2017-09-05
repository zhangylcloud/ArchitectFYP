using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager: MonoBehaviour
{
    public GameObject stair1;
    public GameObject stair2;
    //Hardcode for now, only 100 stairs allowed
    public GameObject[] stairs = new GameObject[100];
    //public bool isInitialized = false;

    private int currentBottom;
    //const int centerNum = 2;
    // Use this for initialization
    void Start()
    {
        currentBottom = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rearrange()
    {
        /*if (curNum == centerNum)
        {
            isInitialized = true;
        }
        if (isInitialized == true && curNum != centerNum)
        {
            if (curNum > centerNum)
            {
                Destroy(stairs[0]);
                for (int i = 1; i < 5; ++i)
                {
                    StairNum curStairNum = stairs[i].GetComponent<StairNum>();
                    curStairNum.stairNum--;
                    stairs[i - 1] = stairs[i];
                }
                GameObject newStair = Instantiate(stair1, new Vector3(stairs[4].transform.position.x, stairs[4].transform.position.y - 6.87f, stairs[4].transform.position.z), Quaternion.identity);
                newStair.GetComponent<StairNum>().stairNum = 4;
                stairs[4] = newStair;
            }
            else if (curNum < centerNum)
            {
                Destroy(stairs[4]);
                for (int i = 3; i >= 0; --i)
                {
                    StairNum curStairNum = stairs[i].GetComponent<StairNum>();
                    curStairNum.stairNum++;
                    stairs[i + 1] = stairs[i];
                }
                GameObject newStair = Instantiate(stair1, new Vector3(stairs[0].transform.position.x, stairs[0].transform.position.y + 6.87f, stairs[0].transform.position.z), Quaternion.identity);
                newStair.GetComponent<StairNum>().stairNum = 0;
                stairs[0] = newStair;
            }
        }*/


    }

    public void GenNew(int curNum)
    {
        if(currentBottom <= curNum)
        {
            GameObject newStair = Instantiate(stair2, new Vector3(stairs[currentBottom].transform.position.x, stairs[currentBottom].transform.position.y - 3.21f, stairs[currentBottom].transform.position.z), Quaternion.identity);
            newStair.GetComponent<StairNum>().stairNum = ++currentBottom;
            stairs[currentBottom] = newStair;
        }
    }
    public void DistroyAll()
    {
        for(int i = 2; i <= currentBottom; ++i)
        {
            if (stairs[i])
            {
                GameObject.Destroy(stairs[i]);
                stairs[i] = null;
            }
            
        }
    }
}

