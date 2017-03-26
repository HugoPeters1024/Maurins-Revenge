using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    float bonus;
    public PlayerControls player;
	// Use this for initialization
	void Start () {
        bonus = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //replay
        if (player.transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}

    private void FixedUpdate()
    {
        if (player.Value == 3)
            bonus+= 0.25f;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(50, 50, Screen.width, Screen.height), "Score: " + ((int)GameScore).ToString(), GUIStyle.none);
        GUI.Box(new Rect(50, 72, Screen.width, Screen.height), "Value: " + player.Value.ToString(), GUIStyle.none);
    }

    public float GameScore
    {
        get { return player.transform.position.x + bonus; }
    }
}

