using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFix : MonoBehaviour {

    // Use this for initialization
    Transform temp;
	void Start () {
        temp = transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = new Quaternion();
	}
}
