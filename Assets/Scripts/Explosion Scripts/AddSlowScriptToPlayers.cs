using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSlowScriptToPlayers : MonoBehaviour {

	public float Radius;

	// Use this for initialization
	void Start () {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject player in players) {
			if (Vector2.Distance (transform.position, player.transform.position) <= Radius) {
				player.AddComponent<SlowScript>();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
