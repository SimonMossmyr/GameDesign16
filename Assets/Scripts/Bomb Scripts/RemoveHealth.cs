using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHealth : MonoBehaviour {

	public float Radius;
	public float Damage;

	// Use this for initialization
	void Start () {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject player in players) {
			if (Vector2.Distance (transform.position, player.transform.position) <= Radius) {
				player.GetComponent<PlayerStats> ().AddHealth (-Damage);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
