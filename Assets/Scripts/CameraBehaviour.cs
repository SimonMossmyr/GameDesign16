﻿using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	private GameObject player;
	private Camera c;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("PlayerCharacter");
		c = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vPos = c.WorldToViewportPoint (player.transform.position);

		Vector3 newPos = vPos;

		if (vPos.x < 0.1f) {
			newPos.x -= 0.1f - vPos.x;
		} else if (vPos.x > 0.9f) {
			newPos.x += vPos.x - 0.9f;
		}

		if (vPos.y < 0.2f) {
			newPos.y -= 0.2f - vPos.y;
		} else if (vPos.y > 0.8f) {
			newPos.y += vPos.y - 0.8f;
		}

		gameObject.transform.Translate (c.ViewportToWorldPoint(newPos) - player.transform.position);
	}
}
