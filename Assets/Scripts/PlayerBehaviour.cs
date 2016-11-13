using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    public float speed = 1f;
	private Rigidbody2D rb2d;

	// Hold whether direction key is pressed
	private bool up = false, down = false, left = false, right = false;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		updateMovement ();

		/*
		 * Calculate directional movement.
		 * Movement per frame is is (1|-1) * delta * speed.
		 */
		float movementX = (right && !left? 1 : (left && !right? -1 : 0)) * Time.deltaTime * speed;
		float movementY = (up && !down? 1 : (down && !up? -1 : 0)) * Time.deltaTime * speed;

		Vector2 movement = new Vector2 (movementX, movementY);

		rb2d.MovePosition (rb2d.position + (movement * speed));
    }

	/*
	 * Update bools holding key-down information
	 */
	void updateMovement () {
		if (Input.GetKeyDown (KeyCode.W) && !up)
			up = true;
		else if (Input.GetKeyUp (KeyCode.W) && up)
			up = false;

		if (Input.GetKeyDown (KeyCode.S) && !down)
			down = true;
		else if (Input.GetKeyUp (KeyCode.S) && down)
			down = false;

		if (Input.GetKeyDown (KeyCode.A) && !left)
			left = true;
		else if (Input.GetKeyUp (KeyCode.A) && left)
			left = false;

		if (Input.GetKeyDown (KeyCode.D) && !right)
			right = true;
		else if (Input.GetKeyUp (KeyCode.D) && right)
			right = false;
	}
}
