using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	private GameObject player;
	private Camera c;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("PlayerCharacter");
		c = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vPos = c.WorldToViewportPoint (player.transform.position);

		Vector2 newPos = new Vector2();

		if (vPos.x < 0.2f) {
			newPos.x -= 0.2f - vPos.x;
		} else if (vPos.x > 0.8f) {
			newPos.x += vPos.x - 0.8f;
		}

		if (vPos.y < 0.2f) {
			newPos.y -= 0.2f - vPos.y;
		} else if (vPos.y > 0.8f) {
			newPos.y += vPos.y - 0.8f;
		}

		gameObject.transform.Translate (newPos);
	}
}
