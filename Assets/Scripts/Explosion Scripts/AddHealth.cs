using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth: MonoBehaviour {

	public float Radius;
	public float Amount;

	// Use this for initialization
	void Start () {

		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject player in players) {
			if (Vector2.Distance (transform.position, player.transform.position) <= Radius) {
				player.GetComponent<PlayerStats> ().AddHealth (Amount);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
