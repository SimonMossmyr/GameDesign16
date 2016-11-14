using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		 * Calculate directional movement.
		 */
		float movementX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float movementY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		/*
		 * Execute movement
		 */
		Vector2 movement = new Vector2 (movementX, movementY);
		rb2d.MovePosition (rb2d.position + movement);
    }
}
