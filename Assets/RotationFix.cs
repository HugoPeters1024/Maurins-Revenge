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
        transform.localPosition = new Vector3(player.transform.position.x-6f + (player.transform.position.y < 50 ? 6*(player.transform.position.y/50) : 6), player.transform.position.y*1.1f+2, player.transform.position.z);
        transform.rotation = Quaternion.Euler(20 + (player.transform.position.y < 50 ? (player.transform.position.y/50)*90 : 90), 90, 0);
	}
}
