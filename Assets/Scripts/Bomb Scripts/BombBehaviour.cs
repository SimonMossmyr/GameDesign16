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


	public void checkCollison(){

        Collider2D[] explosion = Physics2D.OverlapCircleAll (transform.position, range);
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
        Debug.Log(damage + " --- " + effect + " ---  " + range);
	}
}
