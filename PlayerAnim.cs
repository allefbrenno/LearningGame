using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {
    private int onGround;
	// Use this for initialization
	void Start () {
		
	}
	/*
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Jump") == 1 && onGround == 1)
            onGround = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
            onGround = 1;
    }
    */
}
