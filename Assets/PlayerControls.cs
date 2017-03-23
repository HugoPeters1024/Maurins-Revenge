using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float jumpForce;
    public float gravity;
    int distToGround;
    int count;

    // Use this for initialization
    void Start () {
        distToGround = 0;
        count = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
            Physics.gravity = new Vector3(0, -gravity, 0);
        }

        //forward motion
        transform.position += new Vector3(0.1f + count++/60000f, 0, 0);
        if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3(0, 0, 0.07f);
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(0, 0, -0.07f);
	}

    bool isGrounded
    {
        get { return GetComponent<Rigidbody>().velocity.y > -0.1f && GetComponent<Rigidbody>().velocity.y < 0.1f; }
    }
}
