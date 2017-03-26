using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breed : MonoBehaviour {

    public int iterations;
    protected int counter;
    public GameObject copy;
    bool beenCopied;
	// Use this for initialization
	void Start () {
        counter = GetComponentInParent<Breed>().counter;
        beenCopied = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (counter < iterations && !beenCopied)
        {
            copy.transform.localPosition += new Vector3(1, 0, 0);
            counter++;
            Instantiate(copy);
            beenCopied = true;
        }
        transform.localPosition += new Vector3(0.1f, 0, 0);
    }

}
