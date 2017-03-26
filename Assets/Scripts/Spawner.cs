using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour {

    const int levelWidth = 5;
    
    // Use this for initialization
    public Platform prefab;
    public PlayerControls player;
    public AbstractEnemy[] enemies;
    public int sightRange;
    int count;
    float offset;
	void Start () {
        count = 0;
        offset = 0;
	}
	
	// Update is called once per frame
	void Update () {

		while (player.transform.position.x > (count-sightRange))
        {
            offset += Random.Range(0, 2f)-1f;
            for (int i = 0; i < levelWidth; ++i)
            {
                Platform lastSpawn = Instantiate(prefab);
                lastSpawn.gameObject.name = "BasePlatform";
                lastSpawn.Player = player;
                lastSpawn.transform.localPosition += new Vector3(count, 0, offset + i);
                int z = Random.Range(0, 10);
                switch(z)
                {
                    case 0:
                    case 1:
                    case 2:
                        PhysicMaterial m = new PhysicMaterial();
                        m.bounciness = 1;
                        lastSpawn.GetComponent<BoxCollider>().material = m;
                        lastSpawn.GetComponent<Renderer>().material.color = Color.red;
                        lastSpawn.Kind = 1;
                        break;

                    case 3:
                        lastSpawn.GetComponent<Renderer>().material.color = Color.blue;
                        lastSpawn.Kind = 2;
                        break;
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
                        Platform lastSpawn = Instantiate(prefab);
                        lastSpawn.Player = player;
                        lastSpawn.gameObject.name = "PlatformLayer";
                        lastSpawn.transform.localPosition += new Vector3(count+i, 4, offset + j);
                    }
                }
            }

            if ((int)Random.Range(0, 6) == 0)
            {
                AbstractEnemy e = enemies[(int)Random.Range(0, enemies.GetLength(0))];
                AbstractEnemy lastSpawn = Instantiate(e);
                lastSpawn.name = "AbstractEnemy";
                lastSpawn.player = player;
                lastSpawn.transform.localPosition = new Vector3(count, 1, (int)Random.Range(0, 3) + offset);
                lastSpawn.transform.Rotate(0, 270, 0);
            }
            count++;
        }
	}
}
