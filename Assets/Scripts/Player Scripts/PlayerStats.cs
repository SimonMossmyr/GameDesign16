using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	[Range(0,1)]
	public int PlayerNumber;
	public float HealthPoints;
	public int Lives;

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

		}
	}
}
