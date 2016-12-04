using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

    public float speed;
	private Rigidbody2D rb2d;
	private int playerNumber;

	[SyncVar(hook = "DirHook")]
    private int facingDirection = 6;

	[SyncVar(hook = "MovingHook")]
	private bool moving = false;

    private float deadZone = 0.1f;
    private SpriteAnimator animator;

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		playerNumber = gameObject.GetComponent<PlayerStats> ().PlayerNumber;
        animator = transform.GetComponentInChildren<SpriteAnimator>();

    }
	
	// FixedUpdate is called once per physics frame
	void FixedUpdate () {

		UpdateAnimation ();

		if (!isLocalPlayer)
		{
			return;
		}

        /*
		 * Calculate directional movement.
		 */
        float rawAxisX = Input.GetAxisRaw("Horizontal");
        float rawAxisY = Input.GetAxisRaw("Vertical" );

        float movementX = rawAxisX * Time.deltaTime * speed;
		float movementY = rawAxisY * Time.deltaTime * speed;

		int newDir = facingDirection;

        // Update facing direction
        if(rawAxisX == 0 && rawAxisY == 0)
        {
			CmdChangeDir (newDir, false);
			this.moving = false;
        }
        else
        {
            if (rawAxisX > deadZone && rawAxisY == 0)
            {
				newDir = 0;
            }
            else if (rawAxisY > deadZone && rawAxisX == 0)
            {
				newDir = 2;
            }
            else if (rawAxisX < deadZone && rawAxisY == 0)
            {
				newDir = 4;
            }
            else if (rawAxisY < deadZone && rawAxisX == 0)
            {
				newDir = 6;
			}

			if (newDir != facingDirection || !moving) {
				CmdChangeDir (newDir, true);
				this.moving = true;
				this.facingDirection = newDir;
			}
		}

        /*
		 * Execute movement
		 */
        Vector2 movement = new Vector2 (movementX, movementY);
		rb2d.MovePosition (rb2d.position + movement);
    }

	public void UpdateAnimation() {
		if (moving) {
			Debug.Log ("Derp" + facingDirection);
			switch (facingDirection) {
			case 0:
				if (animator.currentAnimation.name == "IdleEast" || animator.currentAnimation.name == "IdleNorth" || animator.currentAnimation.name == "IdleWest" || animator.currentAnimation.name == "IdleSouth")
					animator.Play ("WalkingEast");
				break;
			case 2:
				if (animator.currentAnimation.name == "IdleEast" || animator.currentAnimation.name == "IdleNorth" || animator.currentAnimation.name == "IdleWest" || animator.currentAnimation.name == "IdleSouth")
					animator.Play ("WalkingNorth");
				break;
			case 4:
				if (animator.currentAnimation.name == "IdleEast" || animator.currentAnimation.name == "IdleNorth" || animator.currentAnimation.name == "IdleWest" || animator.currentAnimation.name == "IdleSouth")
					animator.Play ("WalkingWest");
				break;
			case 6:
				if (animator.currentAnimation.name == "IdleEast" || animator.currentAnimation.name == "IdleNorth" || animator.currentAnimation.name == "IdleWest" || animator.currentAnimation.name == "IdleSouth")
					animator.Play ("WalkingSouth");
				break;
			}
		} else {
			switch (facingDirection) {
			case 0:
				animator.Play("IdleEast");
				break;
			case 2:
				animator.Play("IdleNorth");
				break;
			case 4:
				animator.Play("IdleWest");
				break;
			case 6:
				animator.Play("IdleSouth");
				break;
			}
		}
	}

	public void DirHook(int dir) {
	}

	public void MovingHook(bool moving) {
	}

	[Command]
	void CmdChangeDir(int dir, bool moving) {
		this.facingDirection = dir;
		this.moving = moving;
	}

	public void AddSpeed(float amount) {
		speed += amount;
	}

    public int getFacingDirection()
    {
        return facingDirection;
    }
}
