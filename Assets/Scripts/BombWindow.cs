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

    Image slot1; // damage
    Image slot2; // heal
    Image slot3; // slow

    [SerializeField]
    GameObject bombStandart;
   
    Material materal,material2,material3;

    int []bombslotId = new int[3];
    int[] bombAttributes = new int[3];
    float[,] bombSlotAttr = new float[3,3];

    int mat1Number, mat2Number, mat3Number;

    GameObject createdBomb;
    BombBehaviour defaultBombBeh;

    //we do this so that we can easily access to the material attributes
    Material material1 = new Material();
    Material materialtype2 = new Material();
    Material materialtype3 = new Material();

    // Use this for initialization
    void Start () {

        // se the attributes here 
        material1.setDamage(0.5f);
        material1.setEffect(0.6f);
        material1.setRange(1);

        materialtype2.setDamage(0.2f);
        materialtype2.setEffect(0.5f);
        materialtype2.setRange(0.2f);

        materialtype3.setDamage(0.4f);
        materialtype3.setEffect(0.7f);
        materialtype3.setRange(0.3f);

        // we put the number of materials used for bomb crafted. See the "returnMaterial" method for how it happens
        bombslotId[0] = 0;
        bombslotId[1] = 0;
        bombslotId[2] = 0;

        // comes from the old demo. We add all the bombs to player 2. Delete this if you want player 2 to craft materials


        Image[] bombSlotCanvas = playerBombInventoryCanvas.GetComponentsInChildren<Image>();

        foreach (Image go in bombSlotCanvas)
        {
            Debug.Log(go.name);

            if ( go.name == "BombSlot1Image" )
            {
                slot1 = go;
            }
            else if( go.name == "BombSlot2Image" )
            {
                slot2 = go;
            }
            else if( go.name == "BombSlot3Image")
            {
                slot3 = go;
            }
        }


        PlayerStats curPlayer = gameObject.GetComponent<PlayerStats>();
        playerNumber = curPlayer.PlayerNumber;

    }
	
    public void calculateBombEffect(int mat1, int mat2, int mat3)
    {
        mat1Number = mat1;
        mat2Number = mat2;
        mat3Number = mat3;

        //encode the value to keep the materials used for bombs
        int bombMaterialCount = (100 * mat1) + (10 * mat2) + mat3;
        
        if (!isFirstSlotFilled)
        {
            //set the sprite of the bomb slot
            slot1.sprite = slot1BombSprite;
            //set the flag to true to know if it has a bomb
            isFirstSlotFilled = true;
            //add the number of material used to the array
            bombslotId[0] = bombMaterialCount;

            //calculate the effects of the materials. Mat1, mat2, mat3 are the number of material1 ,2 etc.
            bombSlotAttr[0, 0] = mat1 * material1.getDamage() + mat2 * materialtype2.getDamage() + mat3 * materialtype3.getDamage();
            bombSlotAttr[0, 1] = mat1 * material1.getEffect() + mat2 * materialtype2.getEffect() + mat3 * materialtype3.getEffect();
            bombSlotAttr[0, 2] = mat1 * material1.getRange() + mat2 * materialtype2.getRange() + mat3 * materialtype3.getRange();
        } 
        //if not, add to second slot 
        else if (!isSecondSlotFilled)
        {
            slot2.sprite = slot1BombSprite;
            isSecondSlotFilled = true;
            bombslotId[1] = bombMaterialCount;

            bombSlotAttr[1, 0] = mat1 * material1.getDamage() + mat2 * materialtype2.getDamage() + mat3 * materialtype3.getDamage();
            bombSlotAttr[1, 1] = mat1 * material1.getEffect() + mat2 * materialtype2.getEffect() + mat3 * materialtype3.getEffect();
            bombSlotAttr[1, 2] = mat1 * material1.getRange() + mat2 * materialtype2.getRange() + mat3 * materialtype3.getRange();
        }

        //if not add to third
        else if (!isThirdFilled)
        {
            slot3.sprite = slot1BombSprite;
            isThirdFilled = true;
            bombslotId[2] = bombMaterialCount;

            bombSlotAttr[2, 0] = mat1 * material1.getDamage() + mat2 * materialtype2.getDamage() + mat3 * materialtype3.getDamage();
            bombSlotAttr[2, 1] = mat1 * material1.getEffect() + mat2 * materialtype2.getEffect() + mat3 * materialtype3.getEffect();
            bombSlotAttr[2, 2] = mat1 * material1.getRange() + mat2 * materialtype2.getRange() + mat3 * materialtype3.getRange();
        }
    }

    // slot is: which bomb slot is used
    void returnMaterials(int slot)
    {

        int totalMatCount = bombslotId[slot];
        //decode the values for the bombs
        int mat1RetCount = totalMatCount / 100;
        int mat2RetCount = totalMatCount % 100 / 10;
        int mat3RetCount = totalMatCount % 10;

        // return the materials to the inventory. I wrote another method 
        // because otherwise I would have to use a for loop here and get the current count
        // from the script and set them new each time 
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
                // create an instance of the standart bomb and add the range, effect and damage attributes to it
                GameObject asd = (GameObject)Instantiate(bombStandart, player.transform.position, Quaternion.identity);
                defaultBombBeh = asd.GetComponent<BombBehaviour>();
                defaultBombBeh.setDamage(bombSlotAttr[0, 0]);
                defaultBombBeh.setRange(bombSlotAttr[0, 1]);
                defaultBombBeh.setEffect(bombSlotAttr[0, 2]);

                //set the sprite to empty 
                slot1.sprite = emptySlotSprite;
                //set the slot empty
                isFirstSlotFilled = false;
                // this is for which slot is called. 
                // so here i am saying: first slot is empty, return the material from the first slot
                returnMaterials(0);

            }
        }
        if (playerNumber == 2 && Input.GetKeyDown("[2]")
            || playerNumber == 1 && Input.GetKeyDown("2"))
        {
            if (isSecondSlotFilled)
            {
                GameObject asd = (GameObject)Instantiate(bombStandart, player.transform.position, Quaternion.identity);
                defaultBombBeh = asd.GetComponent<BombBehaviour>();
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
                defaultBombBeh = asd.GetComponent<BombBehaviour>();
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
