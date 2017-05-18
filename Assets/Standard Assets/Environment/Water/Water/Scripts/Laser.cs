﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public float laserPower;
    public GameObject prefab;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Ray beam = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(beam.origin, beam.direction * 1000f, Color.red);
        RaycastHit beamHit = new RaycastHit();
        if (Physics.Raycast(beam, out beamHit, 1000f))
        {
            if (beamHit.rigidbody && Input.GetMouseButton(0))
            {
                beamHit.rigidbody.AddForce(Random.insideUnitSphere * laserPower);
            }
            if (beamHit.rigidbody && Input.GetMouseButton(2))
            {
                Instantiate(prefab, beamHit.point, Quaternion.identity);
            }
            if (Input.GetMouseButton(1))
            {
                Destroy(beamHit.transform.gameObject);
            }
        }
	}
}
