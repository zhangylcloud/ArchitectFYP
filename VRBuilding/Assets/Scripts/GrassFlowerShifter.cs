using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassFlowerShifter : MonoBehaviour {
    public GameObject grass;
    public GameObject flower;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shift()
    {
        grass.SetActive(false);
        flower.SetActive(true);
    }
}
