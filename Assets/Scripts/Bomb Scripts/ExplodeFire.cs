using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeFire : MonoBehaviour {

	public float Countdown;
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

		// Two explosions east
		delta = new Vector2(ExplosionSpacing, 0f);
		CreateParticleEffect ((Vector2)transform.position + delta);

		delta = new Vector2(2*ExplosionSpacing, 0f);
		CreateParticleEffect ((Vector2)transform.position + delta);

		// Two explosions north
		delta = new Vector2(0f, ExplosionSpacing);
		CreateParticleEffect ((Vector2)transform.position + delta);

		delta = new Vector2(0f, 2*ExplosionSpacing);
		CreateParticleEffect ((Vector2)transform.position + delta);

		// Two explosions west
		delta = new Vector2(-ExplosionSpacing, 0f);
		CreateParticleEffect ((Vector2)transform.position + delta);

		delta = new Vector2(-2*ExplosionSpacing, 0f);
		CreateParticleEffect ((Vector2)transform.position + delta);

		// Two explosions south
		delta = new Vector2(0f, -ExplosionSpacing);
		CreateParticleEffect ((Vector2)transform.position + delta);

		delta = new Vector2(0f, -2*ExplosionSpacing);
		CreateParticleEffect ((Vector2)transform.position + delta);

		Destroy (gameObject);
	}

	private void CreateParticleEffect(Vector2 position) {
		GameObject explosion = Instantiate (ExplosionEffect);
		explosion.transform.position = position;
	}
}
