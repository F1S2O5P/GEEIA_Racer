using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {
	public double velocity;
	public double RPM;
	public int gear = 1;
	public double maxRPM = 6500;
	public double minRPM = 850;
	public double maxThrottle = 350;
	public double curThrottle = 0;
	private double rotAngle;
	public int maxGears = 5;
	public int gearMaxSpeed = 22;
	public string drivetrainType = "F";
	private Rigidbody2D wheel;
	private Rigidbody2D car;
	// Use this for initialization
	void Start () {
		Transform wheelT = findWheel (drivetrainType);
		if (wheelT == null) {
			Debug.LogError ("can't get wheel object!");
			return;
		}
		wheel = wheelT.gameObject.GetComponent<Rigidbody2D> ();
		car = GetComponent<Rigidbody2D> ();
		RPM = minRPM;
	}

	private Transform findWheel(string type) {
		Transform[] ts = transform.GetComponentsInChildren<Transform>();
		foreach (Transform t in ts) {
			Debug.Log (t.gameObject.name);
			if (t.gameObject.name == "tire" + type)
				return t;
		}
		return null;
	}

	// Update is called once per frame
	void Update () {
		RPM += curThrottle;
		if (RPM > minRPM)
			RPM -= 100;
		// -- przeniesienie napedu --
		velocity = (RPM/maxRPM)*gearMaxSpeed;
		//if(wheel != null) wheel.AddTorque (-(float)velocity);
		car.transform.Translate(new Vector3((float)velocity/100f,0f,0f));
		wheel.transform.Rotate (Vector3.forward * (float) (-velocity/100f));
		rotAngle += velocity/100f;
	}

	public void accel(double throttle) {
		if(curThrottle < maxThrottle) curThrottle += (throttle*50);
		if (throttle == 0)
			curThrottle = 0;
	}
}
