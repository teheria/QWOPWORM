using UnityEngine;
using System.Collections;

public class ClientGUI : MonoBehaviour {
	
	public string targetIP;
	public int connectPort;
	
	private SelectClient _sc;
	
	void Start()
	{
		targetIP = gameObject.GetComponent<SelectClient>().targetIP;
		connectPort = gameObject.GetComponent<SelectClient>().connectPort;
		
		_sc = gameObject.GetComponent<SelectClient>();
	}
	
	void OnGUI()
	{
		
		GUILayout.BeginVertical();
		targetIP = GUILayout.TextField(targetIP, GUILayout.MinWidth(100));
		connectPort = int.Parse(GUILayout.TextField(connectPort.ToString()));
		if (GUILayout.Button ("Connect"))
		{
			_sc.Connect();
		}
	}
}
