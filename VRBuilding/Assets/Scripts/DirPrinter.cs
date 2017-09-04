using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirPrinter : MonoBehaviour {
    public Transform[] dirs = new Transform[6];
    public Transform[] words= new Transform[6];
    public Quaternion[] rotations = new Quaternion[6];
	// Use this for initialization
	void Start () {
        /*for(int i = 0; i < 6; ++i)
        {
            Debug.Log(dirs[i].gameObject.name + " " + dirs[i].rotation);
        }*/
        rotations[0] = new Quaternion(0, 0, 0, 1);
        rotations[1] = new Quaternion(0, 0, 1, 0);
        rotations[2] = new Quaternion(0.7f, 0, 0, 0.7f);
        rotations[3] = new Quaternion(-0.7f, 0, 0, 0.7f);
        rotations[4] = new Quaternion(0, 0, -0.7f, 0.7f);
        rotations[5] = new Quaternion(0, 0, 0.7f, 0.7f);
        for(int i = 0; i < 6; ++i)
        {
            words[i].rotation = rotations[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
