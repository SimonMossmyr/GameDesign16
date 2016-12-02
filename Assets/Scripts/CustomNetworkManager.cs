using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

	private int playerIndex = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
		var player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
		player.GetComponent<PlayerStats> ().PlayerNumber = playerIndex;
		playerIndex++;
    NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}
}
