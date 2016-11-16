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
    MaterialType type;



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

    public int getHealth()
    {
        return health;
    }

    //what type of material is that 
    public MaterialType getMaterialType()
    {
        return type;
    }
}
