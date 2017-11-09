using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVehicleMover : MonoBehaviour {
	private Vehicle vehicle;
	// Use this for initialization
	void Start () {
		vehicle = GetComponent<Vehicle> ();
		if (vehicle == null) {
			Debug.LogError ("Component Vehicle not found!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (vehicle != null) {
			if (Input.GetKeyDown ("up")) {
				vehicle.accel (1);
			}
			if (Input.GetKeyUp ("up")) {
				vehicle.accel (0);
			}
		}
	}
}
