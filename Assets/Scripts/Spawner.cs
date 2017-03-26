using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour {

    const int levelWidth = 5;
    
    // Use this for initialization
    public GameObject prefab;
    public GameObject player;
    public AbstractEnemy[] enemies;
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

		while (player.transform.position.x > (count-sightRange))
        {
            offset += Random.Range(0, 2f)-1f;
            for (int i = 0; i < levelWidth; ++i)
            {
                lastSpawn = Instantiate(prefab);
                lastSpawn.transform.localPosition += new Vector3(count, 0, offset + i);
                if (Random.Range(0, 4) == 0)
                {
                    PhysicMaterial m = new PhysicMaterial();
                    m.bounciness = 1;
                    lastSpawn.GetComponent<BoxCollider>().material = m;
                    lastSpawn.GetComponent<Renderer>().material.color = Color.red;
                }
            }

            if ((int)Random.Range(0, 6) == 0)
            {
                int q = Random.Range(1, 5);
                for (int i = 0; i < q; ++i)
                {
                    int z = Random.Range(1, 5);
                    for (int j = 0; j < z; ++j)
                    {
                        lastSpawn = Instantiate(prefab);
                        lastSpawn.gameObject.name = "Platform Layer";
                        lastSpawn.transform.localPosition += new Vector3(count+i, 4, offset + j);
                    }
                }
            }

            if ((int)Random.Range(0, 6) == 0)
            {
                AbstractEnemy e = enemies[(int)Random.Range(0, enemies.GetLength(0))];
                lastSpawn = Instantiate(e.gameObject);
                lastSpawn.name = "AbstractEnemy";
                lastSpawn.transform.localPosition = new Vector3(count, 1, (int)Random.Range(0, 3) + offset);
                lastSpawn.transform.Rotate(0, 270, 0);
            }
            count++;
        }
	}
}
