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

	void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
		
	}
}
