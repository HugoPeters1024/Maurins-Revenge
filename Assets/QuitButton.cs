using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour {

    // Use this for initialization
    public string nameStr;
    public List<ScoreType> scores;
    public Score scoreValue;

    public struct ScoreType
    {
        public string name;
        public int value;

        public ScoreType(string name, int value)
        {
            this.name = name;
            this.value = value;
        }

    }

    void Start () {
        nameStr = "";
        if (!File.Exists("highscores.txt"))
            File.Create("highscores.txt");
        StreamReader fs = new StreamReader("highscores.txt");
        scores = new List<ScoreType>();
        while(!fs.EndOfStream)
        {
            string tmp = fs.ReadLine();
            scores.Add(new ScoreType(tmp.Split(';')[0], int.Parse(tmp.Split(';')[1])));
        }
        fs.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if (transform.position.y < 5)
        {
            GUI.Box(new Rect(40, Screen.height / 2 + 108, 150, 20), "Name must be at least 5 characters", GUIStyle.none);
            if (GUI.Button(new Rect(40, Screen.height / 2 + 90, 150, 20), "Quit and save..."))
            {
                if (nameStr.Length >= 5)
                {
                    scores.Add(new ScoreType(nameStr, scoreValue.GameScore));
                    scores = scores.OrderByDescending(o => o.value).ToList();
                    StreamWriter fs = new StreamWriter("highscores.txt");
                    foreach(ScoreType sc in scores)
                    {
                        fs.WriteLine(sc.name + ";" + sc.value);
                    }
                    fs.Close();
                    SceneManager.LoadScene(1);
                }
            }
            nameStr = GUI.TextField(new Rect(40, Screen.height / 2 + 40, 150, 40), nameStr);
        }
    }
}