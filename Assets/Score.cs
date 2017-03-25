using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    int score;
    public PlayerControls player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        score = (int)player.transform.position.x;

        //replay
        if (player.transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}

    private void OnGUI()
    {
        GUI.Box(new Rect(50, 50, Screen.width, Screen.height), "Score: " + ((int)player.transform.position.x).ToString(), GUIStyle.none);
        GUI.Box(new Rect(50, 72, Screen.width, Screen.height), "Value: " + player.Value.ToString(), GUIStyle.none);
    }
}
