using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {

    public int damage, effect, range;

	// Use this for initialization
	void Start () {
        damage = effect = range = 0;
	}
	
    public void setDamage(int val)
    {
        Debug.Log("called");
        damage = val;
    }

    public void setEffect(int val)
    {
        Debug.Log("called2");
        effect = val;
    }

    public void setRange(int val)
    {
        Debug.Log("called3");
        range = val;
    }

	// Update is called once per frame
	void Update () {
        Debug.Log(damage + " --- " + effect + " ---  " + range);
	}
}
