using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    float bonus;
    public PlayerControls player;
    // Use this for initialization
    string[] valDescr;
	void Start () {
        bonus = 0;
        valDescr = new string[6]
        {
            "1 -> double speed",
            "2 -> higher jump",
            "3 -> score multiplier",
            "4 -> retarded cats and name reset",
            "5 -> micro-gravity",
            "6 -> destroy blocks on contact"
        };
	}
	
	// Update is called once per frame
	void Update () {
        //replay
        if (player.transform.position.y < -5)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(1);
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
        GUIStyle style = new GUIStyle();
        style.fontStyle = FontStyle.Bold;
        for (int i = 0; i < 6; ++i)
        {
            GUI.Box(new Rect(50, 90 + 18*i, Screen.width, Screen.height), valDescr[i], player.Value == i+1 ? style : GUIStyle.none);
        }
    }

    public int GameScore
    {
        get { return (int)(player.transform.position.x + bonus); }
    }
}

