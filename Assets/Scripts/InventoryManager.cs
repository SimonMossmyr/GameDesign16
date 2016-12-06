using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    //inventory of the player
    private List<Material> itemsInInventory = new List<Material>();

    // this is the canvas that displays total number of material the player has 
    // it is visible all the time and should be added to the scene prior to the game
    GameObject playerMaterialInventoryWindow;

    // for getting the player number 
    PlayerStats playerStat;
    int playerNumber;

    int material1Count, material2Count, material3Count;

    // material sound
    public AudioSource collectionSound;
    
    // Use this for initialization
    void Start () {
        material1Count = material2Count = material3Count = 0;
        playerStat = gameObject.GetComponent<PlayerStats>();
        playerNumber = playerStat.PlayerNumber;
        playerMaterialInventoryWindow = GameObject.Find("Player" + playerNumber + "MaterialPanel");
    }
	
	// Update is called once per frame
	void Update () {
    
        // update the material texts 
        Text[] bombSlotCanvas = playerMaterialInventoryWindow.GetComponentsInChildren<Text>();

        foreach (Text go in bombSlotCanvas)
        {
            if (go.name == "Material1Text")
            {
               go.text = "" + material1Count;
            }
            else if (go.name == "Material2Text")
            {
                go.text = "" + material2Count;
            }
            else if (go.name == "Material3Text")
            {
                go.text = "" + material3Count;
            }
        }

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

    public void returnMaterial1(int val)
    {
        material1Count+=val;
    }
    public void returnMaterial2(int val)
    {
        material2Count += val;
    }
    public void returnMaterial3(int val)
    {
        material3Count += val;
    }

    //collision with the materials in the scene
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);

        if ( other.gameObject.tag == "Material")
        {
            collectionSound.Play();

            Material collidedMaterial = other.gameObject.GetComponent<Material>();

            if (collidedMaterial.getMaterialType() == Material.MaterialType.Material1)
                material1Count++;
            else if (collidedMaterial.getMaterialType() == Material.MaterialType.Material2)
                material2Count++;
            else if (collidedMaterial.getMaterialType() == Material.MaterialType.Material3)
                material3Count++;

            itemsInInventory.Add(other.gameObject.GetComponent<Material>());

            Destroy(other.gameObject);
        }
    }

}
