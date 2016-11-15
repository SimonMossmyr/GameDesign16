using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour {

    // Use this for initialization

    Canvas CanvasObject;
    [SerializeField]
    private Text material1Text;
    [SerializeField]
    private Text material2Text;
    [SerializeField]
    private Text material3Text;


    void Start () {
        CanvasObject = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<Canvas>();
        CanvasObject.enabled = false;
    }

    public void onClick()
    {
        // Save game data
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.tag == "Player1Corner")
        {
            CanvasObject.enabled = true;
            List<Material> items = gameObject.GetComponent<InventoryManager>().getInventoryList();

            int mat1 = 0;
            int mat2 = 0;
            int mat3 = 0;
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

            material1Text.text = mat1 + "";
            material2Text.text = mat2 + "";
            material3Text.text = mat3 + "";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1Corner")
        {
            CanvasObject.enabled = false;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
