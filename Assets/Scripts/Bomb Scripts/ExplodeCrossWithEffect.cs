using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCrossWithEffect : MonoBehaviour {

	public float Countdown;
	public int NumberOfExplosionsInEachDirection;
	public float ExplosionSpacing;
	public GameObject ExplosionEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Countdown -= Time.deltaTime;

		if (Countdown <= 0f) {
			Explode ();
		}
	}

	private void Explode() {

		Vector2 delta;

		// Explosion centered at the bomb
		CreateParticleEffect(transform.position);

		// Explosions east
		for (int i = 1; i <= NumberOfExplosionsInEachDirection; i++) {
			delta = new Vector2(i*ExplosionSpacing, 0f);
			CreateParticleEffect ((Vector2)transform.position + delta);
		}

		// Explosions north
		for (int i = 1; i <= NumberOfExplosionsInEachDirection; i++) {
			delta = new Vector2(0f, i*ExplosionSpacing);
			CreateParticleEffect ((Vector2)transform.position + delta);
		}

		// Explosions west
		for (int i = 1; i <= NumberOfExplosionsInEachDirection; i++) {
			delta = new Vector2(-i*ExplosionSpacing, 0f);
			CreateParticleEffect ((Vector2)transform.position + delta);
		}

		// Explosions south
		for (int i = 1; i <= NumberOfExplosionsInEachDirection; i++) {
			delta = new Vector2(0f, -i*ExplosionSpacing);
			CreateParticleEffect ((Vector2)transform.position + delta);
		}

		BombBehaviour explosionBehaviour = gameObject.GetComponent<BombBehaviour> ();
		explosionBehaviour.checkCollison ();
		Destroy (gameObject);
	}

	private void CreateParticleEffect(Vector2 position) {
		GameObject explosion = Instantiate (ExplosionEffect);
		explosion.transform.position = position;
	}
}
