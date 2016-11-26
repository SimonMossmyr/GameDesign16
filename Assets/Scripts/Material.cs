using UnityEngine;
using System.Collections;

public class Material : MonoBehaviour {

    public enum MaterialType { Material1, Material2, Material3 };

    //take as an input from the editor
    [SerializeField]
    int health = 2;

    [SerializeField]
    int damage = 4;

    [SerializeField]
    int slow = 5;

    [SerializeField]
    MaterialType type;

    [SerializeField]
    int effect = 0;

    [SerializeField]
    int range = 0;

    // Use this for initialization
    void Start () {
	
	}
	


	// Update is called once per frame
	void Update () {

	}

    //getters for health and damage
    public int getDamage()
    {
        return damage;
    }

    public void setDamage(int val)
    {
        damage = val;
    }

    public int getHealth()
    {
        return health;
    }

    public void setHealth(int val)
    {
        health = val;
    }

    public int getSlow()
    {
        return slow;
    }

    public void setSlow(int val)
    {
        slow = val;
    }

    //getters for health and damage
    public int getEffect()
    {
        return effect;
    }

    public void setEffect(int val)
    {
        effect = val;
    }


    //getters for health and damage
    public int getRange()
    {
        return range;
    }

    public void setRange(int val)
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
