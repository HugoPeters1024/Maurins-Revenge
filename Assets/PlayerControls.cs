using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {

    public float jumpForce;
    public float m_speed;
    public float gravity;
    QuitButton quitButton;
    int count;
    int value;
    /*
     * 1 -> double speed
     * 2 -> higher jump
     * 3 -> score multiplier
     * 4 -> immunity
     * 5 -> decreased gravity
     * 6 -> destroy blocks on contact
    */
    Color[] playerColor = new Color[6]
    {
        Color.blue,
        Color.cyan,
        Color.green,
        Color.magenta,
        Color.yellow,
        Color.black
    };

    // Use this for initialization
    void Start () {
        count = 0;
        transform.position = new Vector3(0, 2, 10);
        quitButton = GetComponent<QuitButton>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, (value == 2 ? jumpForce*1.5f : jumpForce), 0));
        }

        //forward motion
        float speed = value == 1 ? m_speed * 2 : m_speed;
        transform.position += new Vector3(speed + count++/60000f, 0, 0);
        if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3(0, 0, speed);
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(0, 0, -speed);

        if (isGrounded)
        {
            int v = CalcSideUp();
            if (v != 0 && v != value)
            {
                value = v;
                GetComponent<Renderer>().material.color = playerColor[v-1];
                if (value == 4)
                {
                    quitButton.nameStr = "";
                }
            }
        }

        //change gravity on 5
        Physics.gravity = Value == 5 ? new Vector3(0, -gravity * 0.15f, 0) : new Vector3(0, -gravity, 0);

    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "AbstractEnemy":
                SceneManager.LoadScene(1);
                break;

            case "PlatformLayer":
                if (Value == 6)
                    Destroy(collision.gameObject);
                break;
        }
    }

    int CalcSideUp()
    {
        float dotFwd = Vector3.Dot(transform.forward, Vector3.up);
        if (dotFwd > 0.99f) return 1;
        if (dotFwd < -0.99f) return 6;

        float dotRight = Vector3.Dot(transform.right, Vector3.up);
        if (dotRight > 0.99f) return 4;
        if (dotRight < -0.99f) return 3;

        float dotUp = Vector3.Dot(transform.up, Vector3.up);
        if (dotUp > 0.99f) return 2;
        if (dotUp < -0.99f) return 5;

        return 0;
    }

    bool isGrounded
    {
        get { return GetComponent<Rigidbody>().velocity.y > -0.1f && GetComponent<Rigidbody>().velocity.y < 0.1f; }
    }

    public int Value
    {
        get { return value; }
    }
}
