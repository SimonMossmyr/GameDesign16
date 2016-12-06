using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	[Range(0,1)]
	public int PlayerNumber;
	public float HealthPoints;
	private float actionTime;
	public float actionDuration = 0.5f;
	public int Lives;
	public GameObject PlayerBase;

	// Use this for initialization
	void Start () {
		PlayerBase = GameObject.Find ("Player" + PlayerNumber + "Base");
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
			Destroy (gameObject);
		} else {
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
			gameObject.GetComponent<Rigidbody2D> ().position = PlayerBase.transform.position;
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			HealthPoints = 100;
		}
	}

	public void TimeAction()
	{
		actionTime = Time.realtimeSinceStartup;
	}

	private float timeSinceLastAction()
	{
		return Time.realtimeSinceStartup - actionTime;
	}

	public bool actionDurationOver()
	{
		return (timeSinceLastAction() > actionDuration);
	}
}
