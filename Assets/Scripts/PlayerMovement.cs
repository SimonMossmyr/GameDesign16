using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;
	private Rigidbody2D rb2d;
	private int playerNumber;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		playerNumber = gameObject.GetComponent<PlayerStats> ().PlayerNumber;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		 * Calculate directional movement.
		 */
		float movementX = Input.GetAxis("Horizontal-P"+playerNumber) * Time.deltaTime * speed;
		float movementY = Input.GetAxis("Vertical-P"+playerNumber) * Time.deltaTime * speed;

		/*
		 * Execute movement
		 */
		Vector2 movement = new Vector2 (movementX, movementY);
		rb2d.MovePosition (rb2d.position + movement);
    }
}
