using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xd : MonoBehaviour {
    private Rigidbody2D passat;
	// Use this for initialization
	void Start () {
        passat = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up"))
        {
            Destroy(this.gameObject);
            passat.AddRelativeForce(Vector2.up, ForceMode2D.Force);
        }
	}
}
