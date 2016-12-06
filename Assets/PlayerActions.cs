using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerActions : NetworkBehaviour {

    private PlayerStats playerStats;
    private PlayerMovement movement;
    private SpriteAnimator animator;

	// Use this for initialization
	void Start () {
        playerStats = transform.GetComponent<PlayerStats>();
        movement = transform.GetComponent<PlayerMovement>();
        animator = transform.GetComponentInChildren<SpriteAnimator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;
        if (Input.GetButton("Pick axe"))
        {
            if (movement.getFacingDirection() == 0)
                animator.Play("MiningEast");
            if (movement.getFacingDirection() == 2)
                animator.Play("MiningNorth");
            if (movement.getFacingDirection() == 4)
                animator.Play("MiningWest");
            if (movement.getFacingDirection() == 6)
                animator.Play("MiningSouth");
        }
    }
}
