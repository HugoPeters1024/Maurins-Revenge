using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Use this for initialization
    public GameObject prefab;
    public GameObject player;
    GameObject lastSpawn;
    int count;
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        print(player.transform.position.x);
		if (player.transform.position.x > (count-2))
        {
            lastSpawn = Instantiate(prefab);
            lastSpawn.transform.localPosition += new Vector3(count, 0, 0);
            count++;
        }
	}
}
