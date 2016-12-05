using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SourceBehaviour : NetworkBehaviour {

    public GameObject materialToSpawn;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	[Command]
	public void CmdDestroySource() {
		var material = (GameObject) Instantiate(materialToSpawn, transform.position, Quaternion.identity);

		NetworkServer.Spawn (material);
	}
}
