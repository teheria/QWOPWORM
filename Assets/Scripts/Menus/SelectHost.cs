using UnityEngine;
using System.Collections;

public class SelectHost : MonoBehaviour {

	public int connectPort = 25001;
	public bool useNat = false;
	
	private NetworkView _titleNetworkView;
	
	void Start()
	{
		_titleNetworkView = GameObject.Find ("Title").GetComponent<NetworkView>();
	}
	
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			useNat = !Network.HavePublicAddress();
			Network.InitializeServer(1, connectPort, useNat);
			_titleNetworkView.RPC("ServerReady", RPCMode.AllBuffered);
		}
	}
	
	//Server functions called by Unity
	void OnPlayerConnected(NetworkPlayer player) 
	{
		Debug.Log("Player connected from: " + player.ipAddress +":" + player.port);
		_titleNetworkView.RPC("ClientReady", RPCMode.AllBuffered);
	}
	
	void OnServerInitialized() 
	{
		Debug.Log("Server initialized.");
	}
	
	void OnPlayerDisconnected(NetworkPlayer player) 
	{
		Debug.Log("Player disconnected from: " + player.ipAddress+":" + player.port);
	}
}