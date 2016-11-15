using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Destroys a ParticleSystem after it's no longer alive. 
 */
public class DestroyParticleSystem : MonoBehaviour {

	private ParticleSystem ps;

	void Start () {
		ps = GetComponent<ParticleSystem>();
	}

	void Update () {
		if(ps)
		{
			if(!ps.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}
}
