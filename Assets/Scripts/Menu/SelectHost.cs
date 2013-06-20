using UnityEngine;
using System.Collections;

public class SelectHost : MonoBehaviour {

	public int connectPort = 25001;
	public bool useNat = false;
	
	private NetworkView _titleNetworkView;
	private Color _initialColor;
	private Color WHITE = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	
	void Start()
	{
		_titleNetworkView = GameObject.Find ("Title").GetComponent<NetworkView>();
		
		_initialColor = renderer.material.color;
	}
	
	void OnMouseOver()
	{
		renderer.material.color = WHITE;
		if (Input.GetMouseButtonDown(0))
		{
			Network.InitializeServer(1, connectPort, useNat);
			_titleNetworkView.RPC("ServerReady", RPCMode.AllBuffered);
		}
	}
	
	void OnMouseExit()
	{
		renderer.material.color = _initialColor;
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