using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class GameController : MonoBehaviour
{

    SteamVR_TrackedObject trackedObj;
    public GameObject player;
    public SpaceManager spaceManager;
    //public Movement movement;
    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("[CameraRig]");
        spaceManager = GameObject.Find("SpaceManager").GetComponent<SpaceManager>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPress(SteamVR_Controller.ButtonMask.ButtonB))
        {
            ResetGame();
        }
        //Debug.Log("isButtonPressed" + isButtonPressed);
    }
    void ResetGame()
    {
        
    }
}
