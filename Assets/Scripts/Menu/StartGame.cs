using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
	private bool _clientReady = false, _serverReady = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_clientReady && _serverReady)
		{
			networkView.RPC("LoadGame", RPCMode.All);
		}
	}
	
	[RPC]
	void ClientReady()
	{
		_clientReady = true;
	}
	
	[RPC]
	void ServerReady()
	{
		_serverReady = true;
	}
	
	[RPC]
	void LoadGame()
	{
		Application.LoadLevel("Level");
	}
}
