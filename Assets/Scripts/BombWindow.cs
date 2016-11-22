using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class BombWindow : MonoBehaviour {

    //canvas of the player
    [SerializeField]
    Canvas playerBombInventoryCanvas;

    //player transform for getting the position of the player
    [SerializeField]
    GameObject player;

    //player 1 or player 2. Needed to figure out which keypad values to listen
    [SerializeField]
    int playerNumber = 1;

    //to see which slots are filled
    bool isFirstSlotFilled = false;
    bool isSecondSlotFilled = false;
    bool isThirdFilled = false;

    //sprite for empty bomb slot
    [SerializeField]
    Sprite emptySlotSprite;

    //bomb icons (sprites) for the slots
    [SerializeField]
    Sprite slot1BombSprite;
    [SerializeField]
    Sprite slot2BombSprite;
    [SerializeField]
    Sprite slot3BombSprite;

    //empty bomb slots that will be filled
    [SerializeField]
    Image slot1; // damage
    [SerializeField]
    Image slot2; // heal
    [SerializeField]
    Image slot3; // slow

    [SerializeField]
    GameObject bombDamage;
    [SerializeField]
    GameObject bombHeal;
    [SerializeField]
    GameObject bombSlow;

    List<Material> itemsInInventory;
    Material materal,material2,material3;

    // Use this for initialization
    void Start () {

        materal = new Material();
        materal.setDamage(26);
        materal.setHealth(2);
        materal.setSlow(2);

        material2 = new Material();
        material2.setDamage(26);
        material2.setHealth(2);
        material2.setSlow(2);

        material3 = new Material();
        material3.setDamage(26);
        material3.setHealth(2);
        material3.setSlow(2);



        if (playerNumber == 2)
        {
            isFirstSlotFilled = isSecondSlotFilled = isThirdFilled = true;
            slot1.sprite = slot1BombSprite; // damage
            slot2.sprite = slot2BombSprite; // heal 
            slot3.sprite = slot3BombSprite; // slow
        }

	}
	
    //called from inventory window when a bomb is created. 
    public void fillBombs(int craftedBomb)
    {
        //initialize the list
        itemsInInventory = gameObject.GetComponent<InventoryManager>().getInventoryList();

        Debug.Log(craftedBomb);
        //if the first slot if not filled, add the bomb to the slot
        Sprite bombSprite = null;
        if (craftedBomb == 1)
        {
            bombSprite = slot1BombSprite; // damage
            materal.setMaterialType(Material.MaterialType.Material1);
            itemsInInventory.Add(materal);
        }

        else if (craftedBomb == 3)
        {
            bombSprite = slot2BombSprite; // heal 
            materal.setMaterialType(Material.MaterialType.Material1);
            material2.setMaterialType(Material.MaterialType.Material2);
            itemsInInventory.Add(materal);
            itemsInInventory.Add(material2);
        }
        else if(craftedBomb == 6) { 
            bombSprite = slot3BombSprite; // slow
            materal.setMaterialType(Material.MaterialType.Material1);
            material2.setMaterialType(Material.MaterialType.Material2);
            material3.setMaterialType(Material.MaterialType.Material3);
            itemsInInventory.Add(materal);
            itemsInInventory.Add(material2);
            itemsInInventory.Add(material3);
        }

        if ( !isFirstSlotFilled)
        {
            slot1.sprite = bombSprite;
            //set the flag to true to know if it has a bomb
            isFirstSlotFilled = true;
        }
        //if not, add to second slot 
        else if ( !isSecondSlotFilled )
        {
            slot2.sprite = bombSprite;
            isSecondSlotFilled = true;
        }
        //if not add to third
        else if(!isThirdFilled)
        {
            slot2.sprite = bombSprite;
            isThirdFilled = true;
        }
    }

	// Update is called once per frame
	void Update () {

        

        //update the position of the canvas relative to the player position
        Vector3 pos = player.transform.position;
        //update the values so the canvas appears on the top right
        pos.y += 0.5f;
        pos.x += 0.6f;
        //give the position to the canvas position
        playerBombInventoryCanvas.transform.position = pos;

        if ( playerNumber == 2 && Input.GetKeyDown("[1]")
            || playerNumber == 1 && Input.GetKeyDown("1"))
        {
            if ( isFirstSlotFilled)
            {
                //drop the bomb
                slot1.sprite = emptySlotSprite;
                isFirstSlotFilled = false;
                Instantiate(bombDamage, player.transform.position, Quaternion.identity);
                    
                gameObject.GetComponent<InventoryManager>().setInventoryList(itemsInInventory);

            }
        }
        if (playerNumber == 2 && Input.GetKeyDown("[2]")
            || playerNumber == 1 && Input.GetKeyDown("2"))
        {
            if (isSecondSlotFilled)
            {
                //drop the bomb
                slot2.sprite = emptySlotSprite;
                isSecondSlotFilled = false;
                Instantiate(bombHeal, player.transform.position, Quaternion.identity);

                gameObject.GetComponent<InventoryManager>().setInventoryList(itemsInInventory);
            }
        }
        if (playerNumber == 2 && Input.GetKeyDown("[3]")
            || playerNumber == 1 && Input.GetKeyDown("3"))
        {
            if (isThirdFilled)
            {
                //drop the bomb
                slot3.sprite = emptySlotSprite;
                isThirdFilled = false;
                Instantiate(bombSlow, player.transform.position, Quaternion.identity);
        
                gameObject.GetComponent<InventoryManager>().setInventoryList(itemsInInventory);

            }
        }
    }
}
