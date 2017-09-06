using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoasterTrigger : MonoBehaviour {
    GameObject player;
    Transform tmpPlayerTrans;
    Transform cameraEyeTrans;
    string triggerName;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("[CameraRig]");
        triggerName = gameObject.name;
        cameraEyeTrans = GameObject.Find("Camera (eye)").transform;
        tmpPlayerTrans = GameObject.Find("TmpPlayer").transform;
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
            if (tmpPlayerTrans.GetComponent<SplineWalker>().enabled == false && triggerName == "RollerCoasterTriggerStart")
            {
                tmpPlayerTrans.transform.position = new Vector3(cameraEyeTrans.position.x, player.transform.position.y, cameraEyeTrans.position.z);
                player.transform.SetParent(tmpPlayerTrans);

                tmpPlayerTrans.GetComponent<SplineWalker>().enabled = true;
            }
            else if (tmpPlayerTrans.GetComponent<SplineWalker>().enabled == true && triggerName == "RollerCoasterTriggerEnd")
            {
                player.transform.SetParent(null);
                tmpPlayerTrans.GetComponent<SplineWalker>().enabled = false;
            }
        }
        

    }
}
