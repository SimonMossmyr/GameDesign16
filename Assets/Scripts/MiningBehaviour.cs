using UnityEngine;
using UnityEngine.Networking;

public class MiningBehaviour : NetworkBehaviour
{
	private Rigidbody2D playerRb2d;
	private PlayerMovement pm;
    private float lastActionTime;
    public float actionDuration = 0.5f;

	void Start()
	{
		playerRb2d = gameObject.GetComponent<Rigidbody2D> ();
		pm = gameObject.GetComponent<PlayerMovement> ();
	}

	void Update()
	{
		if (!isLocalPlayer)
			return;
		
		if (Input.GetButton ("Pick axe")) {
            if( Time.realtimeSinceStartup > lastActionTime + actionDuration)
            {
                CmdMine();
            }
		}
	}

	[Command]
	public void CmdMine() {
        lastActionTime = Time.realtimeSinceStartup;

		Vector2 direction = Vector2.down;

		if (pm.getFacingDirection() == 4) {
			direction = Vector2.left;
		} else if (pm.getFacingDirection() == 2) {
			direction = Vector2.up;
		} else if (pm.getFacingDirection() == 0) {
			direction = Vector2.right;
		} else if (pm.getFacingDirection() == 6) {
			direction = Vector2.down;
		}

		int layermask = 1 << LayerMask.NameToLayer ("Obstacles");
		RaycastHit2D hit = Physics2D.Raycast (playerRb2d.position, direction, 1.1f, layermask);

		if (hit.collider != null) {
			if (hit.collider.gameObject.CompareTag ("Obstacles")) {
				hit.collider.gameObject.GetComponent<ObstacleBehaviour> ().TakeHit ();
			}
		}
	}
}