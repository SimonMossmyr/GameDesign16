using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InventoryManager : MonoBehaviour {

    //inventory of the player
    private List<Material> itemsInInventory = new List<Material>();


    int material1Count, material2Count, material3Count;

    // Use this for initialization
    void Start () {
        material1Count = material2Count = material3Count = 0;
    }
	
	// Update is called once per frame
	void Update () {
	}

    //return the inventory list if needed
    public List<Material> getInventoryList()
    {
        return itemsInInventory;
    }

    public void setInventoryList(List<Material> val)
    {
        itemsInInventory = val;
    }

    public int getMaterial1Count()
    {
        return material1Count;
    }
    public void setMaterial1Count(int val)
    {
        material1Count = val;
    }
    public void incrementMaterial1()
    {
        material1Count++;
    }


    public int getMaterial2Count()
    {
        return material2Count;
    }
    public void setMaterial2Count(int val)
    {
        material2Count = val;
    }
    public void incrementMaterial2()
    {
        material2Count++;
    }

    public int getMaterial3Count()
    {
        return material3Count;
    }
    public void setMaterial3Count(int val)
    {
        material3Count = val;
    }
    public void incrementMaterial3()
    {
        material3Count++;
    }

    //collision with the materials in the scene
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);

        if ( other.gameObject.tag == "Material")
        {
            Material collidedMaterial = other.gameObject.GetComponent<Material>();

            if (collidedMaterial.getMaterialType() == Material.MaterialType.Material1)
                material1Count++;
            else if (collidedMaterial.getMaterialType() == Material.MaterialType.Material2)
                material2Count++;
            else
                material3Count++;

            itemsInInventory.Add(other.gameObject.GetComponent<Material>());

            Destroy(other.gameObject);
        }
    }

}
