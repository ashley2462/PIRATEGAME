using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour {
    //made public so they show up on the inspector
    //whatever number is changed in the program will always be multiplied by 1000
    public float turnSpeed = 1000f;
    public float accellerateSpeed = 1000f;
    private Rigidbody rbody;
	// Use this for initialization
	void Start () {
        //Made the boat parent a rbody
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //Float is a number with decimal points
        // Input for moving the ship
        // Makes having adjustments to speed possible
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        //Turn speed and acceleration
        //Torque is a rotational force
        //x=0, h= "left and right", turnspeed = how strong to turn it, time.deltatime = z=0
        rbody.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
        //force pushes
        //transform.forward pushes forward in any direction it facing, v = "up and down" accelleratedspeed = how fast moving foward
        rbody.AddForce(transform.forward * v * accellerateSpeed * Time.deltaTime);
    }
}
