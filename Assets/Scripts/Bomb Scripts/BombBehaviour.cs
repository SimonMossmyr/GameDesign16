using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {

    public int damage, effect, range;

    bool floag;

	// Use this for initialization
	void Start () {
        //damage = effect = range = 0;
        floag = false;
    }
	
    public void setDamage(int val)
    {
        damage = val;
        floag = true;
        Debug.Log("called " + damage + " ---- " + effect+ " --- " + range);
    }

    public void setEffect(int val)
    {
        Debug.Log("called2");
        effect = val;
    }

    public int getDamage()
    {
        return damage;
    }

    public int getEffect()
    {
        return effect;
    }

    public int getRange()
    {
        return range;
    }

    public void setRange(int val)
    {
        Debug.Log("called3");
        range = val;
    }

	// Update is called once per frame
	void Update () {
        Debug.Log(damage + " --- " + effect + " ---  " + range);
        if (floag)
            Debug.Log("asdasdasdsadasdas " + damage);
	}
}
