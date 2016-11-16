using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour
{
	private int playerIndex;
	private Animator animator;

	// Use this for initialization
	void Start()
	{
		playerIndex = transform.parent.GetComponent<PlayerStats>().PlayerNumber;
		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

		var vertical = Input.GetAxis("Vertical-P"+playerIndex);
		var horizontal = Input.GetAxis("Horizontal-P"+playerIndex);

		if (vertical > 0)
		{
			animator.SetInteger("Direction", 2);
		}
		else if (vertical < 0)
		{
			animator.SetInteger("Direction", 0);
		}
		else if (horizontal > 0)
		{
			animator.SetInteger("Direction", 3);
		}
		else if (horizontal < 0)
		{
			animator.SetInteger("Direction", 1);
		}
	}
}