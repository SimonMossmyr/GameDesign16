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

    // call this function inside the for loop, then it will draw spheres in the effect place of the bombs
    // use this to see if the player was supposed to be damaged. 
    void bombEffectDebugging(Vector2 delta)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        cube.transform.position = (Vector2)transform.position + delta;
    }

    private void Explode() {

        BombBehaviour bombStats = gameObject.GetComponent<BombBehaviour>();

        Vector2 delta;

		// Explosion centered at the bomb
		CreateParticleEffect(transform.position, bombStats.getEffect());


        float radius = bombStats.getRange();
        
        // Explosions east
        for (int i = 1; i <= NumberOfExplosionsInEachDirection; i++) {
			delta = new Vector2(i*radius, 0f);
			CreateParticleEffect ((Vector2)transform.position + delta, bombStats.getEffect());
            //create circle and check player collisions
            bombStats.checkCollison((Vector2)transform.position + delta);
        }

		// Explosions north
		for (int i = 1; i <= NumberOfExplosionsInEachDirection; i++) {
			delta = new Vector2(0f, i* radius);
			CreateParticleEffect ((Vector2)transform.position + delta, bombStats.getEffect());
            bombStats.checkCollison((Vector2)transform.position + delta);
        }

		// Explosions west
		for (int i = 1; i <= NumberOfExplosionsInEachDirection; i++) {
			delta = new Vector2(-i* radius, 0f);
			CreateParticleEffect ((Vector2)transform.position + delta, bombStats.getEffect());
            bombStats.checkCollison((Vector2)transform.position + delta);
        }

		// Explosions south
		for (int i = 1; i <= NumberOfExplosionsInEachDirection; i++) {
			delta = new Vector2(0f, -i* radius);
			CreateParticleEffect ((Vector2)transform.position + delta, bombStats.getEffect());
            bombStats.checkCollison((Vector2)transform.position + delta);
        }
		Destroy (gameObject);
	}

    private void CreateParticleEffect(Vector2 position, float bombEffect) {
		GameObject explosion = Instantiate (ExplosionEffect);
		explosion.transform.position = position;

        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
         
        Color explosionColor = Color.cyan;
        if (bombEffect % 5 == 0)
        {
            explosionColor = Color.blue;
        }
        else if (bombEffect % 7 == 0)
        {
            explosionColor = Color.magenta;
        }
        else if (bombEffect % 13 == 0)
        {
            explosionColor = Color.green;
        }
        else if ( bombEffect % (5+7) == 0)
        {
            explosionColor = Color.cyan;
        }
        else if ( bombEffect % (5+13) == 0)
        {
            explosionColor = Color.red;
        } 
        else if ( bombEffect % (7+13) == 0)
        {
            explosionColor = new Color(0.647059f, 0.164706f, 0.164706f);
        }
        else
        {
            explosionColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
        ps.startColor = explosionColor;

        float hue;
        float sat;
        float val;
        Color.RGBToHSV(explosionColor, out hue, out sat, out val);

        ps.GetComponentInChildren<Light>().color = Color.HSVToRGB(hue, 0.95f, 0.95f);

    }
}