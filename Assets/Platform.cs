using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    int kind;
    public int despawnDistance;
    PlayerControls player;
	// Use this for initialization
	void Start () {
        kind = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x - transform.position.x > despawnDistance)
            Destroy(gameObject);
    }

    public int Kind
    {
        get { return kind; }
        set { kind = value; }
    }

    public PlayerControls Player
    {
        set { player = value; }
    }
}
