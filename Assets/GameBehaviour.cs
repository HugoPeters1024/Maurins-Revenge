using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //restart the game if the players falls out the world.
		if (transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
