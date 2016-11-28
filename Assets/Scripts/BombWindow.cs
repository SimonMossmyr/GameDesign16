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
    GameObject bombStandart;
   
    Material materal,material2,material3;

    int []bombslotId = new int[3];

    int mat1Number, mat2Number, mat3Number;

    GameObject createdBomb;
    BombBehaviour defaultBombBeh;

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
	
    public void calculateBombEffect(int mat1, int mat2, int mat3)
    {
    

        if (!isFirstSlotFilled)
        {
            slot1.sprite = slot1BombSprite;
            //set the flag to true to know if it has a bomb
            isFirstSlotFilled = true;
        }
        //if not, add to second slot 
        else if (!isSecondSlotFilled)
        {
            slot2.sprite = slot1BombSprite;
            isSecondSlotFilled = true;
        }

        //if not add to third
        else if (!isThirdFilled)
        {
            slot3.sprite = slot1BombSprite;
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

                GameObject asd = (GameObject)Instantiate(bombStandart, player.transform.position, Quaternion.identity);
                defaultBombBeh = asd.GetComponent<BombBehaviour>();
                defaultBombBeh.damage = 2;
                defaultBombBeh.setDamage(4);
                slot1.sprite = emptySlotSprite;
                isFirstSlotFilled = false;
            }
        }
        if (playerNumber == 2 && Input.GetKeyDown("[2]")
            || playerNumber == 1 && Input.GetKeyDown("2"))
        {
            if (isSecondSlotFilled)
            {
                Instantiate(bombStandart, player.transform.position, Quaternion.identity);
                slot2.sprite = emptySlotSprite;
                isSecondSlotFilled = false;
            }
        }
        if (playerNumber == 2 && Input.GetKeyDown("[3]")
            || playerNumber == 1 && Input.GetKeyDown("3"))
        {
            if (isThirdFilled)
            {
                Instantiate(bombStandart, player.transform.position, Quaternion.identity);
                //drop the bomb
                slot3.sprite = emptySlotSprite;
                isThirdFilled = false;
  
            }
        }
    }
}
