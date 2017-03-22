using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    int score;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        score = (int)player.transform.position.x;
	}

    private void OnGUI()
    {
        GUI.Box(new Rect(50, 50, Screen.width, Screen.height), "Score: " + ((int)player.transform.position.x).ToString(), GUIStyle.none);
    }
}
