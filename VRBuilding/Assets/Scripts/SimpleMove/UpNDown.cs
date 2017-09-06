using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpNDown : MonoBehaviour {
    public float moveSpeed;
    public float moveRange;
    private float totalMove;
    private bool upODown;
    Vector3 speedVec;
    public int dir;
    private Vector3[] dirVecs = new Vector3[3];
    
	// Use this for initialization
	void Start () {
        
        upODown = true;
        totalMove = 0;
        dirVecs[0] = new Vector3(0, 1, 0);
        dirVecs[1] = new Vector3(1, 0, 0);
        dirVecs[2] = new Vector3(0, 0, 1);
    }
	
	// Update is called once per frame

	void Update () {
        speedVec = dirVecs[dir] * moveSpeed * Time.deltaTime;
        if (upODown)
        {
            transform.Translate(speedVec);
            totalMove += (dir == 0 ? speedVec.y : (dir == 1) ? speedVec.x : speedVec.z);
            if (totalMove > moveRange)
            {
                upODown = !upODown;
                totalMove = 0;
            }
        }
        else
        {
            transform.Translate(-1 * speedVec);
            totalMove -= (dir == 0 ? speedVec.y : (dir == 1) ? speedVec.x : speedVec.z);
            if (totalMove < -moveRange)
            {
                upODown = !upODown;
                totalMove = 0;
            }
        }
	}
}
