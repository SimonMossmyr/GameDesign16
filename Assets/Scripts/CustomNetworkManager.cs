using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

	private int playerIndex = 0;

	NetworkManagerHUD hud;

	// Use this for initialization
	void Start () {
		hud = gameObject.GetComponent<NetworkManagerHUD> ();
	}

	// Update is called once per frame
	void Update () {
		if (!hud.showGUI && Input.GetKeyDown (KeyCode.Escape)) {
			StopClient ();
			StopServer ();
		}
	}

	public override void OnStopClient() {
		hud.showGUI = true;
	}

	public override void OnStopServer() {
		hud.showGUI = true;
		playerIndex = 0;
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
		GameObject SpawnPoint = GameObject.Find ("Player" + playerIndex + "Base");
		var player = (GameObject)Instantiate(playerPrefab, SpawnPoint.transform.position, Quaternion.identity);
		player.GetComponent<PlayerStats> ().PlayerNumber = playerIndex;
		playerIndex++;
    	NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

		hud.showGUI = false;
	}
}
