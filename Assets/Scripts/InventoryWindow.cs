using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;

/*
    Class for handling the canvas drawing. 

    There are two canvas in the scene. 1 for each player. Reason for this is beacuse I was not able to figure out how to use one canvas and 
    populate with different values for different players. This needs to be fixed.
*/
public class InventoryWindow : NetworkBehaviour {

    // Use this for initialization
    //inventory canvas
    [SerializeField]
    Canvas CanvasObject;

    // text field for displaying the number of material each player has
   
    private Text material1Text;
   
    private Text material2Text;
   
    private Text material3Text;

    //material slot when the player presses the keys to craft a bomb

    Image slot1;
    
    Image slot2;
    
    Image slot3;

    //sprites for replacing the empty material slot when the key is pressed
    [SerializeField]
    Sprite slot1Sprite;
    [SerializeField]
    Sprite slot2Sprite;
    [SerializeField]
    Sprite slot3Sprite;

    //sprite for empty slot. Needed because I can't use Resource.Load since the sprites are not located in the resources folder.
    //also it is 8pm (or later)
    [SerializeField]
    Sprite emptySlotSprite;
    
    // player 1 or player 2. So we know if we should use canvas 1 or canvas 2
    int playerNumber;

    //player 1 inventory canvas or player 2 inventory canvas
    protected string canvasTagName;

    //number of materials. Material 1, 2 and 3
    int mat1 = 0;
    int mat2 = 0;
    int mat3 = 0;

    //which slots are filled AKA which materials are used
    bool isSlotOneFilled = false;
    bool isSlotTwoFilled = false;
    bool isSlotThreeFilled = false;

    int bombCombination = 0;

    //how many material 
    int cratedMaterial1, cratedMaterial2, cratedMaterial3;
    //inventory of the player
    InventoryManager inventoryOfThePlayer;

    int numberOfBombsCreated;

    public AudioSource makeBombSound;

    void Start () {

		if (!isLocalPlayer)
			return;

        numberOfBombsCreated = 0;

        Vector2 initializePosition = transform.position; 
        initializePosition.x =  transform.position.x * 0.55f;
        

        CanvasObject = (Canvas)Instantiate(CanvasObject, initializePosition,transform.rotation);

        PlayerStats curPlayer = gameObject.GetComponent<PlayerStats>();
        playerNumber = curPlayer.PlayerNumber;

        cratedMaterial1 = cratedMaterial2 = cratedMaterial3 = 0;


        //decide which canvas to activate. Uses the tags. Tags are important
        canvasTagName = "Player" + playerNumber + "Base";

        Text[] bombSlotCanvas = CanvasObject.GetComponentsInChildren<Text>();

        foreach (Text go in bombSlotCanvas)
        {
            if (go.name == "Player2Material1Number")
            {
                material1Text = go;
            }
            else if (go.name == "Player2Material2Number")
            {
                material2Text = go;
            }
            else if (go.name == "Player2Material3Number")
            {
                material3Text = go;
            }
        }

        Image[] imageSlotImages = CanvasObject.GetComponentsInChildren<Image>();

        foreach (Image go in imageSlotImages)
        {

            if (go.name == "Player2Slot1")
            {
                slot1 = go;
            }
            else if (go.name == "Player2Slot2")
            {
                slot2 = go;
            }
            else if (go.name == "Player2Slot3")
            {
                slot3 = go;
            }
        }

        //deactivate because we do not want it to be shown initially
        CanvasObject.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if the player entered to it's area
        if (other.gameObject.name == canvasTagName)
        {
            //enable the canvas
            CanvasObject.enabled = true;
            //get the player inventory
            inventoryOfThePlayer = gameObject.GetComponent<InventoryManager>();


            mat1 = inventoryOfThePlayer.getMaterial1Count();
            mat2 = inventoryOfThePlayer.getMaterial2Count();
            mat3 = inventoryOfThePlayer.getMaterial3Count();

            //update the text of the inventory canvas
            material1Text.text = mat1 + "";
            material2Text.text = mat2 + "";
            material3Text.text = mat3 + "";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //if the player exits the canvas, deactivate the canvas
        if (other.gameObject.name == canvasTagName)
        {
            CanvasObject.enabled = false;
            //set to 0 because we are re calculating them when the player enters to the area
            mat1 = mat2 = mat3 = 0;
            slot1.sprite = emptySlotSprite;
            slot2.sprite = emptySlotSprite;
            slot3.sprite = emptySlotSprite;
        }
    }

    // for updating the sprites
    void fillSlots(Sprite materialSprite)
    {
        if( !isSlotOneFilled)
        {
            slot1.sprite = materialSprite;
            isSlotOneFilled = true;
        }
        else if (!isSlotTwoFilled)
        {
            slot2.sprite = materialSprite;
            isSlotTwoFilled = true;
        }
        else
        {
            slot3.sprite = materialSprite;
            isSlotThreeFilled = true;
        }
    }

    public void decrementNumberOfCraftedBombs()
    {
        numberOfBombsCreated--;
    }

    // Update is called once per frame
    void Update () {
        //if the canvas is active. We do this because we are listening to keyboad events
	    if( CanvasObject.isActiveAndEnabled )
        {
            // [4] is for numpad 4. And should be for player 2. Rest goes with the same logic.
            if(Input.GetKeyDown("4") && mat1 > 0 )
            {
                //slot 1 is activated
                fillSlots(slot1Sprite);
                //remove the inventory from the inventory list
                mat1--;
                bombCombination += 1;
                cratedMaterial1++;
            }

            if(Input.GetKeyDown("5") && mat2 > 0 )
            {
                fillSlots(slot2Sprite);
                mat2--;
                bombCombination += 2;
                cratedMaterial2++;
            }

            if (Input.GetKeyDown("6") && mat3 > 0 )
            {
                fillSlots(slot3Sprite);
                mat3--;
                bombCombination += 3;
                cratedMaterial3++;
            }
            //update the text in the canvas
            material1Text.text = mat1 + "";
            material2Text.text = mat2 + "";
            material3Text.text = mat3 + "";

            //if the enter key is pressed, we should craft the bombs and shit
            if(Input.GetKeyDown(KeyCode.Return) )
            {
                if ( numberOfBombsCreated <= 2 && isSlotOneFilled || isSlotTwoFilled || isSlotThreeFilled )
                {
                    // play sound
                    makeBombSound.Play();

                    //slots are empty
                    isSlotOneFilled = false;
                    isSlotThreeFilled = false;
                    isSlotTwoFilled = false;
                    //replace with default empty slot sprite
                    slot1.sprite = emptySlotSprite;
                    slot2.sprite = emptySlotSprite;
                    slot3.sprite = emptySlotSprite;

                    inventoryOfThePlayer.setMaterial3Count(mat3);
                    inventoryOfThePlayer.setMaterial2Count(mat2);
                    inventoryOfThePlayer.setMaterial1Count(mat1);


                    BombWindow playerBombWindow = gameObject.GetComponent<BombWindow>();
                    playerBombWindow.calculateBombEffect(cratedMaterial1, cratedMaterial2, cratedMaterial3);

                    bombCombination = 0;
                    //keeps track of how many materials are used. 
                    cratedMaterial1 = 0;
                    cratedMaterial2 = 0;
                    cratedMaterial3 = 0;

                    numberOfBombsCreated++;
                }
            }
        }
	}
}
