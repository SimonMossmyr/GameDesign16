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
    int[] bombAttributes = new int[3];
    int[,] bombSlotAttr = new int[3,3];

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
        mat1Number = mat1;
        mat2Number = mat2;
        mat3Number = mat3;

        int bombMaterialCount = (100 * mat1) + (10 * mat2) + mat3;

        //Debug.Log("Combine this: " + bombMaterialCount);

        if (!isFirstSlotFilled)
        {
            slot1.sprite = slot1BombSprite;
            //set the flag to true to know if it has a bomb
            isFirstSlotFilled = true;

            bombslotId[0] = bombMaterialCount;

            bombSlotAttr[0, 0] = mat1 * 3 + mat2 * 2 + mat3 * 1;
            bombSlotAttr[0, 1] = mat1 * 1 + mat2 * 3 + mat3 * 2;
            bombSlotAttr[0, 2] = mat1 * 2 + mat2 * 1 + mat3 * 3;
        } 
        //if not, add to second slot 
        else if (!isSecondSlotFilled)
        {
            slot2.sprite = slot1BombSprite;
            isSecondSlotFilled = true;
            bombslotId[1] = bombMaterialCount;

            bombSlotAttr[1, 0] = mat1 * 3 + mat2 * 2 + mat3 * 1;
            bombSlotAttr[1, 1] = mat1 * 1 + mat2 * 3 + mat3 * 2;
            bombSlotAttr[1, 2] = mat1 * 2 + mat2 * 1 + mat3 * 3;
        }

        //if not add to third
        else if (!isThirdFilled)
        {
            slot3.sprite = slot1BombSprite;
            isThirdFilled = true;
            bombslotId[2] = bombMaterialCount;

            bombSlotAttr[2, 0] = mat1 * 3 + mat2 * 2 + mat3 * 1;
            bombSlotAttr[2, 1] = mat1 * 1 + mat2 * 3 + mat3 * 2;
            bombSlotAttr[2, 2] = mat1 * 2 + mat2 * 1 + mat3 * 3;
        }
    }

    void returnMaterials(int slot)
    {

        int totalMatCount = bombslotId[slot];

        int mat1RetCount = totalMatCount / 100;
        int mat2RetCount = totalMatCount % 100 / 10;
        int mat3RetCount = totalMatCount % 10;
        
        /*
        Debug.Log("total material used: " + totalMatCount);
        Debug.Log("mats: " + mat1RetCount + " --- " + mat2RetCount + " --- " + mat3RetCount);
        */
        
        gameObject.GetComponent<InventoryManager>().returnMaterial1(mat1RetCount);
        gameObject.GetComponent<InventoryManager>().returnMaterial2(mat2RetCount);
        gameObject.GetComponent<InventoryManager>().returnMaterial3(mat3RetCount);
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
                defaultBombBeh = asd.AddComponent<BombBehaviour>();
                defaultBombBeh.setDamage(bombSlotAttr[0, 0]);
                defaultBombBeh.setRange(bombSlotAttr[0, 1]);
                defaultBombBeh.setEffect(bombSlotAttr[0, 2]);

                slot1.sprite = emptySlotSprite;
                isFirstSlotFilled = false;

                returnMaterials(0);

            }
        }
        if (playerNumber == 2 && Input.GetKeyDown("[2]")
            || playerNumber == 1 && Input.GetKeyDown("2"))
        {
            if (isSecondSlotFilled)
            {
                GameObject asd = (GameObject)Instantiate(bombStandart, player.transform.position, Quaternion.identity);
                defaultBombBeh = asd.AddComponent<BombBehaviour>();
                defaultBombBeh.setDamage(bombSlotAttr[1, 0]);
                defaultBombBeh.setRange(bombSlotAttr[1, 1]);
                defaultBombBeh.setEffect(bombSlotAttr[1, 2]);

                slot2.sprite = emptySlotSprite;
                isSecondSlotFilled = false;
                
                returnMaterials(1);
            }
        }
        if (playerNumber == 2 && Input.GetKeyDown("[3]")
            || playerNumber == 1 && Input.GetKeyDown("3"))
        {
            if (isThirdFilled)
            {
                GameObject asd = (GameObject)Instantiate(bombStandart, player.transform.position, Quaternion.identity);
                defaultBombBeh = asd.AddComponent<BombBehaviour>();
                defaultBombBeh.setDamage(bombSlotAttr[2, 0]);
                defaultBombBeh.setRange(bombSlotAttr[2, 1]);
                defaultBombBeh.setEffect(bombSlotAttr[2, 2]);
                //drop the bomb
                slot3.sprite = emptySlotSprite;
                isThirdFilled = false;

                returnMaterials(2);
            }
        }
    }
}
