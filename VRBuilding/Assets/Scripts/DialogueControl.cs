using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControl : MonoBehaviour {
    public GameObject dialogueBox;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnableDialogue()
    {
        dialogueBox.SetActive(true);
    }
    public void DisableDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
