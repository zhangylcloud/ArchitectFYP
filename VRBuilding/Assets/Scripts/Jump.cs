using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Jump : MonoBehaviour {
    public GameController gameController;
    public const float jumpSpeedSet = 3;
    public const float gravitySet = 9.8f;
    public GameObject tmpPlayer;
    SteamVR_TrackedObject trackedObj;
    public CharacterController charController;
    //public Movement movement;
    public float jumpSpeed = jumpSpeedSet;
    public float gravity = gravitySet;
    public bool isButtonPressed;
    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Use this for initialization
    void Start () {
        tmpPlayer = GameObject.Find("TmpPlayer");
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }
	public float GetJumpSpeedSet()
    {
        return jumpSpeedSet;
    }
    public float GetGravitySet()
    {
        return gravitySet;
    }
	// Update is called once per frame
	void FixedUpdate () {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        isButtonPressed = device.GetPress(SteamVR_Controller.ButtonMask.ButtonA);
        //Debug.Log("isButtonPressed" + isButtonPressed);
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ButtonC))
        {
            if (tmpPlayer.GetComponent<SplineWalker>().enabled)
            {
                tmpPlayer.GetComponent<SplineWalker>().enabled = false;
                Transform player = tmpPlayer.transform.Find("[CameraRig]");
                if (player != null)
                {
                    player.SetParent(null);
                }
            }

            gameController.JumpLevel();
        }
    }
}
