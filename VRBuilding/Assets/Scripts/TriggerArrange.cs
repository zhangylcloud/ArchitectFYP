using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArrange : MonoBehaviour
{
    DungeonManager stairManager;
    // Use this for initialization
    void Start()
    {
        stairManager = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        int stairNum = transform.parent.gameObject.GetComponent<StairNum>().stairNum;
        stairManager.GenNew(stairNum);
    }
}
