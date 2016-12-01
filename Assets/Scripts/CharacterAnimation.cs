using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour
{
	private Animator animator;
	private PlayerMovement pm;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
		pm = this.GetComponentInParent<PlayerMovement>();
	}

	// Update is called once per frame
	void Update()
	{
		if (pm.dir == Dir.South)
		{
			animator.SetInteger("Direction", 0);
		}
		else if (pm.dir == Dir.West)
		{
			animator.SetInteger("Direction", 1);
		}
		else if (pm.dir == Dir.North)
		{
			animator.SetInteger("Direction", 2);
		}
		else if (pm.dir == Dir.East)
		{
			animator.SetInteger("Direction", 3);
		}
	}
}