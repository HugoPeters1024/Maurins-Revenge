using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFlag : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = new Color(205 / 255f, 83 / 255f, 239 / 255f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
