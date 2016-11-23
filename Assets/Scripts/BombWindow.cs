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

    GameObject bombToCreate;
   
    int []bombslotId = new int[3];

    // Use this for initialization
    void Start () {

        bombslotId[0] = 0;
        bombslotId[1] = 0;
        bombslotId[2] = 0;

        if (playerNumber == 2)
        {
            isFirstSlotFilled = isSecondSlotFilled = isThirdFilled = true;
            slot1.sprite = slot1BombSprite; // damage
            slot2.sprite = slot2BombSprite; // heal 
            slot3.sprite = slot3BombSprite; // slow

        }

	}
	
    public GameObject returnMaterialToInventory()
    {
        if (slot1.sprite == slot1BombSprite)
        {
            Debug.Log("damage");

            return bombDamage;
        }

        else if (slot2.sprite == slot2BombSprite)
        {
            Debug.Log("heal");
 
            return bombHeal;
        }
        else if (slot3.sprite == slot3BombSprite)
        {
            Debug.Log("slow");
 
            return bombSlow;
        }
        else
            return null;
    }

    //called from inventory window when a bomb is created. 
    public void fillBombs(int craftedBomb)
    {
        //initialize the list
        itemsInInventory = gameObject.GetComponent<InventoryManager>().getInventoryList();

        Debug.Log(craftedBomb);
        //if the first slot if not filled, add the bomb to the slot
        Sprite bombSprite = null;

        int flag = 0;

        if (craftedBomb == 1){
            bombSprite = slot1BombSprite; // damage
            bombToCreate = bombDamage;
            flag = 1;
        }

        else if (craftedBomb == 3){
            bombSprite = slot2BombSprite; // heal 
            bombToCreate = bombHeal;
            flag = 2;
        }
        else if(craftedBomb == 6) { 
            bombSprite = slot3BombSprite; // slow
            bombToCreate = bombSlow;
            flag = 3;
        }

        if ( !isFirstSlotFilled)
        {
            slot1.sprite = bombSprite;
            //set the flag to true to know if it has a bomb
            isFirstSlotFilled = true;

            bombslotId[0] = flag;

        }
        //if not, add to second slot 
        else if ( !isSecondSlotFilled )
        {
            slot2.sprite = bombSprite;
            isSecondSlotFilled = true;
            bombslotId[1] = flag;
        }
        //if not add to third
        else if(!isThirdFilled)
        {
            slot2.sprite = bombSprite;
            isThirdFilled = true;
            bombslotId[2] = flag;
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
                GameObject bomb ;
                if (bombslotId[0] == 1)
                {
                    bomb = bombDamage;
                    gameObject.GetComponent<InventoryManager>().incrementMaterial1();
                }
                    
                else if (bombslotId[0] == 2)
                {
                    bomb = bombHeal;
                    gameObject.GetComponent<InventoryManager>().incrementMaterial1();
                    gameObject.GetComponent<InventoryManager>().incrementMaterial2();
                }
                    
                else
                {
                    bomb = bombSlow;
                    gameObject.GetComponent<InventoryManager>().incrementMaterial1();
                    gameObject.GetComponent<InventoryManager>().incrementMaterial2();
                    gameObject.GetComponent<InventoryManager>().incrementMaterial3();
                }
                    

                Instantiate(bomb, player.transform.position, Quaternion.identity);
                //drop the bomb
                slot1.sprite = emptySlotSprite;
                isFirstSlotFilled = false;

            }
        }
        if (playerNumber == 2 && Input.GetKeyDown("[2]")
            || playerNumber == 1 && Input.GetKeyDown("2"))
        {
            if (isSecondSlotFilled)
            {
                Debug.Log("adsasadd " + bombslotId[1]);
                GameObject bomb;
                if (bombslotId[1] == 1)
                {
                    bomb = bombDamage;
                    gameObject.GetComponent<InventoryManager>().incrementMaterial1();
                }

                else if (bombslotId[1] == 2)
                {
                    bomb = bombHeal;
                    gameObject.GetComponent<InventoryManager>().incrementMaterial1();
                    gameObject.GetComponent<InventoryManager>().incrementMaterial2();
                }

                else
                {
                    bomb = bombSlow;
                    gameObject.GetComponent<InventoryManager>().incrementMaterial1();
                    gameObject.GetComponent<InventoryManager>().incrementMaterial2();
                    gameObject.GetComponent<InventoryManager>().incrementMaterial3();
                }

                Instantiate(bomb, player.transform.position, Quaternion.identity);
                //drop the bomb
                slot2.sprite = emptySlotSprite;
                isSecondSlotFilled = false;
   
            }
        }
        if (playerNumber == 2 && Input.GetKeyDown("[3]")
            || playerNumber == 1 && Input.GetKeyDown("3"))
        {
            if (isThirdFilled)
            {
                GameObject bomb;
                if (bombslotId[2] == 1)
                {
                    bomb = bombDamage;
                    gameObject.GetComponent<InventoryManager>().incrementMaterial1();
                }

                else if (bombslotId[2] == 2)
                {
                    bomb = bombHeal;
                    gameObject.GetComponent<InventoryManager>().incrementMaterial1();
                    gameObject.GetComponent<InventoryManager>().incrementMaterial2();
                }

                else
                {
                    bomb = bombSlow;
                    gameObject.GetComponent<InventoryManager>().incrementMaterial1();
                    gameObject.GetComponent<InventoryManager>().incrementMaterial2();
                    gameObject.GetComponent<InventoryManager>().incrementMaterial3();
                }

                Instantiate(bomb, player.transform.position, Quaternion.identity);
                //drop the bomb
                slot3.sprite = emptySlotSprite;
                isThirdFilled = false;
  
            }
        }
    }
}
