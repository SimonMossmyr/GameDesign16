using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowScript : MonoBehaviour {

	public float Amount = 3f;
	public float RecoveryPerSecond = 1f;

	private float delta;

	// Use this for initialization
	void Start () {
		GetComponent<PlayerMovement> ().AddSpeed (-Amount);
		delta = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		delta += Time.deltaTime * RecoveryPerSecond;
		GetComponent<PlayerMovement> ().AddSpeed (Time.deltaTime);

		if (Amount - delta <= 0f) {
			Destroy (this);
		}
	}
}
