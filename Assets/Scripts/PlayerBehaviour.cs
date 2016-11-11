using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    public float speed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float movementX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float movementY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(movementX, movementY, 0);
    }
}
