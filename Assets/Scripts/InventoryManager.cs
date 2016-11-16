using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InventoryManager : MonoBehaviour {

    //inventory of the player
    private List<Material> itemsInInventory = new List<Material>();

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(itemsInInventory.Count);

	}

    //return the inventory list if needed
    public List<Material> getInventoryList()
    {
        return itemsInInventory;
    }

    //collision with the materials in the scene
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        if ( other.gameObject.tag == "Material")
        {
            itemsInInventory.Add(other.gameObject.GetComponent<Material>());

            Destroy(other.gameObject);
        }
    }

}
