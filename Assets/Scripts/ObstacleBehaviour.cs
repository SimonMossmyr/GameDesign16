﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ObstacleBehaviour : NetworkBehaviour {

    public float radius = 1.1f;

    public int durability = 3;

	[SyncVar]
    public float durabilityLeft;

    public AudioClip destructionSound;

	// Use this for initialization
	void Start () {
        durabilityLeft = durability;

    }

	// Update is called once per frame
	void Update () {
		if (!isServer)
			return;

        // Restore obstacle durability if not touched for a while
        durabilityLeft += Time.deltaTime * 0.3f;
        if(durabilityLeft>durability)
        {
            durabilityLeft = durability;
        }
	}

  private void DestroyObstacle() {
    AudioSource.PlayClipAtPoint(destructionSound,transform.position);

    SourceBehaviour tmp = gameObject.GetComponent<SourceBehaviour> ();
    if (tmp != null) {
      tmp.CmdDestroySource();
    }
    Destroy(gameObject);
  }

	public void TakeHit() {
		durabilityLeft--;

		// Destroy fully damaged obstacles
		if (durabilityLeft < 1)
		{
			DestroyObstacle();
		}
	}
}
