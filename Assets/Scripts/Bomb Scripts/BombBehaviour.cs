using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {

    public float damage, effect, range;
    
	// Use this for initialization
	void Start () {
    }
	
    public void setDamage(float val)
    {
        damage = val;
    }


	public void checkCollison(Vector2 positionOfExplosionEffect)
    {
        // radius is set to 0.5 because we are creating the sphere now for each created 
        // explosion effect. So the number is fixed.
        Collider2D[] explosion = Physics2D.OverlapCircleAll(positionOfExplosionEffect, 0.5f);
		foreach (Collider2D i in explosion) {
			if (i.gameObject.tag == "Player") {
                Debug.Log("Damage inflicted: " + damage);
                i.gameObject.GetComponent<PlayerStats> ().AddHealth(-damage);
			}
		}
	}
    public void setEffect(float val)
    {
        effect = val;
    }

    public float getDamage()
    {
        return damage;
    }

    public float getEffect()
    {
        return effect;
    }

    public float getRange()
    {
        return range;
    }

    public void setRange(float val)
    {
        range = val;
    }

    // Update is called once per frame
    void Update () {
    }
}
