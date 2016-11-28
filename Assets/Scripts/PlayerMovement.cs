using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

    public float speed;
	private Rigidbody2D rb2d;

    private bool isFacingEast;
    private bool isFacingNorth;

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// FixedUpdate is called once per physics frame
	void FixedUpdate () {
		if (!isLocalPlayer)
		{
			return;
		}

		/*
		 * Calculate directional movement.
		 */

		float movementX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
		float movementY = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
		float rotation = 0;

		if(movementX > 0.0001)
        {
            isFacingEast = true;
            isFacingNorth = false;
			rotation = 0;
        }
        else if (movementX < -0.0001)
        {
            isFacingEast = false;
            isFacingNorth = false;
			rotation = 180;
        }

        if (movementY > 0.0001)
        {
            isFacingNorth = true;
			isFacingEast = false;
			rotation = 270;
        }
        else if (movementY < -0.0001)
        {
            isFacingNorth = false;
			isFacingEast = false;
			rotation = 90;
        }

        /*
		 * Execute movement
		 */
        Vector2 movement = new Vector2 (movementX, movementY);
		Debug.Log (rotation);
		rb2d.MoveRotation (rotation);
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
