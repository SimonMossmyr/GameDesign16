using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;
	private Rigidbody2D rb2d;
	private int playerNumber;

    private int facingDirection = 6;
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
        /*
		 * Calculate directional movement.
		 */
        float rawAxisX = Input.GetAxisRaw("Horizontal-P" + playerNumber);
        float rawAxisY = Input.GetAxisRaw("Vertical-P" + playerNumber);

        float movementX = rawAxisX * Time.deltaTime * speed;
		float movementY = rawAxisY * Time.deltaTime * speed;

        // Update facing direction
        if(rawAxisX == 0 && rawAxisY == 0)
        {
            if (animator.currentAnimation.name == "WalkingEast")
            {
                animator.Play("IdleEast");
            }
            else if (animator.currentAnimation.name == "WalkingNorth")
            {
                animator.Play("IdleNorth");
            }
            else if (animator.currentAnimation.name == "WalkingWest")
            {
                animator.Play("IdleWest");
            }
            else if (animator.currentAnimation.name == "WalkingSouth")
            {
                animator.Play("IdleSouth");
            }
        }
        else
        {
            if (rawAxisX > deadZone && rawAxisY == 0)
            {
                facingDirection = 0;
                if (animator.currentAnimation.name == "IdleEast" || animator.currentAnimation.name == "IdleNorth" || animator.currentAnimation.name == "IdleWest" || animator.currentAnimation.name == "IdleSouth")
                    animator.Play("WalkingEast");
            }
            else if (rawAxisY > deadZone && rawAxisX == 0)
            {
                facingDirection = 2;
                if (animator.currentAnimation.name == "IdleEast" || animator.currentAnimation.name == "IdleNorth" || animator.currentAnimation.name == "IdleWest" || animator.currentAnimation.name == "IdleSouth")
                    animator.Play("WalkingNorth");
            }
            else if (rawAxisX < deadZone && rawAxisY == 0)
            {
                facingDirection = 4;
                if (animator.currentAnimation.name == "IdleEast" || animator.currentAnimation.name == "IdleNorth" || animator.currentAnimation.name == "IdleWest" || animator.currentAnimation.name == "IdleSouth")
                    animator.Play("WalkingWest");
            }
            else if (rawAxisY < deadZone && rawAxisX == 0)
            {
                facingDirection = 6;
                if (animator.currentAnimation.name == "IdleEast" || animator.currentAnimation.name == "IdleNorth" || animator.currentAnimation.name == "IdleWest" || animator.currentAnimation.name == "IdleSouth")
                    animator.Play("WalkingSouth");
            }
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

    public int getFacingDirection()
    {
        return facingDirection;
    }
}
