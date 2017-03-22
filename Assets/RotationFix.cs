using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFix : MonoBehaviour {

    // Use this for initialization
    public GameObject player;
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(player.transform.position.x-6f, player.transform.position.y+2, player.transform.position.z);
        print(player.transform.localPosition.x);
	}
}
