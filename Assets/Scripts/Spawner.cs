using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Use this for initialization
    public GameObject prefab;
    public GameObject player;
    public GameObject[] enemies;
    public int sightRange;
    Random random;
    GameObject lastSpawn;
    int count;
    float offset;
	void Start () {
        count = 0;
        random = new Random();
        offset = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (player.transform.position.x > (count-sightRange))
        {
            offset += Random.Range(0, 2f)-1f;
            lastSpawn = Instantiate(prefab);
            lastSpawn.transform.localPosition += new Vector3(count, 0, offset);
            if ((int)Random.Range(0, 6) == 0)
            {
                int q = (int)Random.Range(1, 4);
                for (int i = 0; i < q; ++i)
                {
                    lastSpawn = Instantiate(prefab);
                    int zScale = Random.Range(1, 5);
                    lastSpawn.transform.localPosition += new Vector3(count + i, 3, offset);
                    lastSpawn.transform.localScale = new Vector3(1, 1, zScale);
                }
            }

            if ((int)Random.Range(0, 6) == 0)
            {
                lastSpawn = Instantiate(enemies[(int)Random.Range(0, enemies.GetLength(0))]);
                lastSpawn.transform.localPosition += new Vector3(count, 1, (int)Random.Range(0, 3) + offset);
                lastSpawn.transform.Rotate(0, 270, 0);
            }
            count++;
        }
	}
}
