using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCtrlFollow : MonoBehaviour {
    public CharacterController charController;
    public Transform hmdEyeTrans;
    public GameObject currentSpace;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        charController.center = new Vector3(hmdEyeTrans.localPosition.x, 0.5f, hmdEyeTrans.localPosition.z);
	}
}
