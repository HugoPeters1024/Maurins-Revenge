using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractEnemy : MonoBehaviour {
    public float movementSpeed;
    public PlayerControls player;
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3((player.Value == 4) ? 0.2f : -movementSpeed, 0, 0);
        if (transform.position.y < -5)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
