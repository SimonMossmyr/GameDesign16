using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public enum Dir { West, North, East, South };

public class PlayerMovement : NetworkBehaviour {

	[SyncVar]
	public Dir dir;

    public float speed;
	private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		dir = Dir.South;
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

		if(movementX > 0.0001)
        {
			dir = Dir.East;
        }
        else if (movementX < -0.0001)
        {
			dir = Dir.West;
        }

        if (movementY > 0.0001)
        {
			dir = Dir.North;
        }
        else if (movementY < -0.0001)
        {
			dir = Dir.South;
        }

		CmdFace (dir);

        /*
		 * Execute movement
		 */
        Vector2 movement = new Vector2 (movementX, movementY);
		rb2d.MovePosition (rb2d.position + movement);
    }

	[Command]
	void CmdFace(Dir dir) {
		this.dir = dir;
	}

	public void AddSpeed(float amount) {
		speed += amount;
	}
}
