using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;
	private Rigidbody2D rb2d;
	private int playerNumber;

    private bool isFacingEast;
    private bool isFacingNorth;

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		playerNumber = gameObject.GetComponent<PlayerStats> ().PlayerNumber;
	}
	
	// FixedUpdate is called once per physics frame
	void FixedUpdate () {
		/*
		 * Calculate directional movement.
		 */
		float movementX = Input.GetAxisRaw("Horizontal-P"+playerNumber) * Time.deltaTime * speed;
		float movementY = Input.GetAxisRaw("Vertical-P"+playerNumber) * Time.deltaTime * speed;

        if(movementX > 0.0001)
        {
            isFacingEast = true;
            isFacingNorth = false;
        }
        else if (movementX < -0.0001)
        {
            isFacingEast = false;
            isFacingNorth = false;
        }

        if (movementY > 0.0001)
        {
            isFacingNorth = true;
            isFacingEast = false;
        }
        else if (movementY < -0.0001)
        {
            isFacingNorth = false;
            isFacingEast = false;
        }

        /*
		 * Execute movement
		 */
        Vector2 movement = new Vector2 (movementX, movementY);
		rb2d.MovePosition (rb2d.position + movement);
    }

	public void AddSpeed(float amount) {
		speed += amount;
	}

    public bool getIsFacingEast()
    {
        return isFacingEast;
    }

    public bool getIsFacingNorth()
    {
        return isFacingNorth;
    }
}
