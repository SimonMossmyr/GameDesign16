using UnityEngine;
using System.Collections;

public class Material : MonoBehaviour {

    public enum MaterialType { Material1, Material2, Material3 };

    //take as an input from the editor
    [SerializeField]
    float health = 2;

    [SerializeField]
    float damage = 4;

    [SerializeField]
    float slow = 5;

    [SerializeField]
    MaterialType type;

    [SerializeField]
    float effect = 0;

    [SerializeField]
    float range = 0;

    // Use this for initialization
    void Start () {
	
	}
	


	// Update is called once per frame
	void Update () {

	}

    //getters for health and damage
    public float getDamage()
    {
        return damage;
    }

    public void setDamage(float val)
    {
        damage = val;
    }

    public float getHealth()
    {
        return health;
    }

    public void setHealth(float val)
    {
        health = val;
    }

    public float getSlow()
    {
        return slow;
    }

    public void setSlow(int val)
    {
        slow = val;
    }

    //getters for health and damage
    public float getEffect()
    {
        return effect;
    }

    public void setEffect(float val)
    {
        effect = val;
    }


    //getters for health and damage
    public float getRange()
    {
        return range;
    }

    public void setRange(float val)
    {
        range = val;
    }


    //what type of material is that 
    public MaterialType getMaterialType()
    {
        return type;
    }

    public void setMaterialType(MaterialType val)
    {
        type = val;
    }


}
