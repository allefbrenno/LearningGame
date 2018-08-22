using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractions : MonoBehaviour {
    public float jumpForce;
    public float spawnDelay;
    private int estate;

    private void Start()
    {
        estate = 0;
    }

    private void Update()
    {
        //comando para dar cooldown
        if(estate != 1)
        {
            spawnDelay -= Time.deltaTime;
            if (spawnDelay <= 0.0f)
                estate = 1;
        }

        //comando para respawn
        if (Input.GetKeyDown("f") && estate == 1)
        {
            transform.position = new Vector3(0, 0, 0);
            estate = 0;
            spawnDelay = 5f;
        }
    }
    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
          
    }

}
