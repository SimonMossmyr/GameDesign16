﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	[Range(0,1)]
	public int PlayerNumber;
	public float HealthPoints;
	public int Lives;
	public GameObject PlayerBase;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddHealth(float delta) {
		HealthPoints += delta;

		if (HealthPoints <= 0f) {
			Kill ();
		}
	}

	// Kills this player
	public void Kill() {
		Lives--;

		if (Lives <= 0) {
			// Lives should never be less than 0, but still
			GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera");
			camera.GetComponent<CameraBehaviour> ().RemovePlayer (gameObject); // remove player from the camera system
			Destroy (gameObject);
		} else {
			print ("Moving player "+gameObject+" to "+PlayerBase.transform.position);
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
			gameObject.GetComponent<Rigidbody2D> ().position = PlayerBase.transform.position;
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	}
}