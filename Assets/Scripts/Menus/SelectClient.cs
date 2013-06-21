using UnityEngine;
using System.Collections;

public class SelectClient : MonoBehaviour {
	
	public int connectPort = 25001;
	public string targetIP = "127.0.0.1";
	
	private ClientGUI _cgui;
	
	void Start()
	{
		_cgui = gameObject.GetComponent<ClientGUI>();
		_cgui.enabled = false;
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_cgui.enabled = true;
		}
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_cgui.enabled = false;
		}
	}
	
	public void Connect()
	{
		Network.Connect(targetIP, connectPort);
	}
	
	//Client functions called by Unity
	void OnConnectedToServer() 
	{
		Debug.Log("This client has connected to a server.");	
	}
	
	void OnDisconnectedFromServer(NetworkDisconnection info) 
	{
		Debug.Log("This server or client has disconnected from a server.");
	}
	
	void OnFailedToConnect(NetworkConnectionError error)
	{
		Debug.Log("Could not connect to server: " + error);
	}
}
