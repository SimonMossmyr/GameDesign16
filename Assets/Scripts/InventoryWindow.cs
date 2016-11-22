using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/*
    Class for handling the canvas drawing. 

    There are two canvas in the scene. 1 for each player. Reason for this is beacuse I was not able to figure out how to use one canvas and 
    populate with different values for different players. This needs to be fixed.
*/
public class InventoryWindow : MonoBehaviour {

    // Use this for initialization
    //inventory canvas
    Canvas CanvasObject;

    // text field for displaying the number of material each player has
    [SerializeField]
    private Text material1Text;
    [SerializeField]
    private Text material2Text;
    [SerializeField]
    private Text material3Text;

    //material slot when the player presses the keys to craft a bomb
    [SerializeField]
    Image slot1;
    [SerializeField]
    Image slot2;
    [SerializeField]
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
    [SerializeField]
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


    //inventory of the player
    List<Material> items;

    void Start () {

        //initialize the list
        items = new List<Material>();

        //decide which canvas to activate. Uses the tags. Tags are important
        if (playerNumber == 1)
        {
            canvasTagName = "Player1Corner";
            CanvasObject = GameObject.FindGameObjectWithTag("Player1Inventory").GetComponent<Canvas>();
        }
        else
        {
            canvasTagName = "Player2Corner";
            CanvasObject = GameObject.FindGameObjectWithTag("Player2Inventory").GetComponent<Canvas>();
        }

        //deactivate because we do not want it to be shown initially
        CanvasObject.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if the player entered to it's area
        if (other.gameObject.tag == canvasTagName)
        {
            //enable the canvas
            CanvasObject.enabled = true;
            //get the player inventory
            items = gameObject.GetComponent<InventoryManager>().getInventoryList();
            //count the materials the player has
            foreach (Material mat in items)
            {
                if(mat.getMaterialType() == Material.MaterialType.Material1)
                {
                    mat1++;
                }
                else if (mat.getMaterialType() == Material.MaterialType.Material2)
                {
                    mat2++;
                }
                else
                {
                    mat3++;
                }
            }
            //update the text of the inventory canvas
            material1Text.text = mat1 + "";
            material2Text.text = mat2 + "";
            material3Text.text = mat3 + "";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //if the player exits the canvas, deactivate the canvas
        if (other.gameObject.tag == "Player1Corner" || other.gameObject.tag == "Player2Corner")
        {
            CanvasObject.enabled = false;
            //set to 0 because we are re calculating them when the player enters to the area
            mat1 = mat2 = mat3 = 0;
        }
    }

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

    // Update is called once per frame
    void Update () {
        //if the canvas is active. We do this because we are listening to keyboad events
	    if( CanvasObject.isActiveAndEnabled )
        {
            // [4] is for numpad 4. And should be for player 2. Rest goes with the same logic.
            if( Input.GetKeyDown("[4]") && mat1 > 0 && playerNumber == 2
                || Input.GetKeyDown("4") && mat1 > 0 && playerNumber == 1)
            {
                //slot 1 is activated
                fillSlots(slot1Sprite);
                //remove the inventory from the inventory list
                mat1--;

                bombCombination += 1;
                //also remove from the player inventory
                foreach (Material mat in items)
                {
                    if (mat.getMaterialType() == Material.MaterialType.Material1)
                    {
                        items.Remove(mat);
                    }
                }
            }

            if(Input.GetKeyDown("[5]") && mat2 > 0 && playerNumber == 2
                || Input.GetKeyDown("5") && mat2 > 0 && playerNumber == 1)
            {
                fillSlots(slot2Sprite);
                mat2--;
                bombCombination += 2;
                foreach (Material mat in items)
                {
                    if (mat.getMaterialType() == Material.MaterialType.Material2)
                    {
                        items.Remove(mat);
                    }
                }
            }

            if (Input.GetKeyDown("[6]") && mat3 > 0 && playerNumber == 2
                || Input.GetKeyDown("6") && mat3 > 0 && playerNumber == 1)
            {
                fillSlots(slot3Sprite);
                mat3--;
                bombCombination += 3;
                foreach (Material mat in items)
                {
                    if (mat.getMaterialType() == Material.MaterialType.Material3)
                    {
                        items.Remove(mat);
                    }
                }
            }
            //update the text in the canvas
            material1Text.text = mat1 + "";
            material2Text.text = mat2 + "";
            material3Text.text = mat3 + "";

            //if the enter key is pressed, we should craft the bombs and shit
            if(Input.GetKeyDown(KeyCode.KeypadEnter) && playerNumber == 2
                || Input.GetKeyDown(KeyCode.Return) && playerNumber == 1)
            {
                //slots are empty
                isSlotOneFilled = false;
                isSlotThreeFilled = false;
                isSlotTwoFilled = false;
                //replace with default empty slot sprite
                slot1.sprite = emptySlotSprite;
                slot2.sprite = emptySlotSprite;
                slot3.sprite = emptySlotSprite;

                BombWindow playerBombWindow = gameObject.GetComponent<BombWindow>();
                playerBombWindow.fillBombs(bombCombination);
                bombCombination = 0;
            }
        }
	}
}
