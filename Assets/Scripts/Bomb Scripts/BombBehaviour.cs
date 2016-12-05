using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {

    public float damage, effect, range;

    bool floag;

	// Use this for initialization
	void Start () {
        //damage = effect = range = 0;
        floag = false;
    }
	
    public void setDamage(float val)
    {
        damage = val;
        floag = true;
        //Debug.Log("called " + damage + " ---- " + effect+ " --- " + range);
    }


	public void checkCollison(Vector2 positionOfExplosionEffect){

        Collider2D[] explosion = Physics2D.OverlapCircleAll (positionOfExplosionEffect, 2);
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
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, range*2);
    }
    // Update is called once per frame
    void Update () {
        //Gizmos.DrawSphere(transform.position, range);
        
        //Debug.Log(damage + " --- " + effect + " ---  " + range);
    }
}
