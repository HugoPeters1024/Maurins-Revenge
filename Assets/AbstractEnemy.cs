using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractEnemy : MonoBehaviour {
    public float movementSpeed;
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(-movementSpeed, 0, 0);
    }
}
