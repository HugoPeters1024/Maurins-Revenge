using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Use this for initialization
    public GameObject prefab;
    public GameObject player;
    public int sightRange;
    Random random;
    GameObject lastSpawn;
    int count;
	void Start () {
        count = 0;
        random = new Random();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > (count-sightRange))
        {
            lastSpawn = Instantiate(prefab);
            lastSpawn.transform.localPosition += new Vector3(count, 0, 0);
            if ((int)Random.Range(0, 10) == 0)
            {
                lastSpawn = Instantiate(prefab);
                lastSpawn.transform.localPosition += new Vector3(count, 3, 0);
            }
            count++;
        }
	}
}
