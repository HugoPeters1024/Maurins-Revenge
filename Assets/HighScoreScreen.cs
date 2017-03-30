using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreScreen : MonoBehaviour {

    // Use this for initialization
    List<QuitButton.ScoreType> scores;
	void Start () {
        if (!File.Exists("highscores.txt"))
            File.Create("highscores.txt");
        StreamReader fs = new StreamReader("highscores.txt");
        scores = new List<QuitButton.ScoreType>();
        while (!fs.EndOfStream)
        {
            string tmp = fs.ReadLine();
            scores.Add(new QuitButton.ScoreType(tmp.Split(';')[0], int.Parse(tmp.Split(';')[1])));
        }
        fs.Close();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        for (int i = 0; i < Mathf.Min(scores.Count, 10); ++i)
        {
            GUI.Box(new Rect(0, 100 + 20 * i, Screen.width, Screen.height), (i+1).ToString() + ". " +scores[i].name + ": " + scores[i].value, new GUIStyle { fontSize = 16, alignment = TextAnchor.UpperCenter });
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 10, 100, 15), "Play Again"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
