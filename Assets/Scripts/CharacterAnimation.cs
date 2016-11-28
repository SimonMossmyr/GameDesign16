using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour
{
	private Animator animator;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
		rb2d = this.GetComponentInParent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update()
	{
		if (rb2d.rotation == 0) {
			animator.SetInteger("Direction", 3);
		} else if (rb2d.rotation == 90) {
			animator.SetInteger("Direction", 2);
		} else if (rb2d.rotation == 180) {
			animator.SetInteger("Direction", 1);
		} else if (rb2d.rotation == 270) {
			animator.SetInteger("Direction", 0);
		}
	}
}