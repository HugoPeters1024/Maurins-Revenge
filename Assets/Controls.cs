using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
    public float forwardSpeed;
    Rigidbody m_Rigidbody;

    float speed;
    // Use this for initialization
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float sideMovement = 0;
        if (Input.GetKey(KeyCode.A))
            sideMovement += 0.2f;
        if (Input.GetKey(KeyCode.D))
            sideMovement -= 0.2f;

        Vector3 v = new Vector3(forwardSpeed, 0, sideMovement);

        m_Rigidbody.velocity += v;
	}
}
