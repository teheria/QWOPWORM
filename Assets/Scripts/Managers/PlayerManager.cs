using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	
	[HideInInspector]
	public enum PlayingAs { MAN, WORM, NULL };
	
	[HideInInspector]
	public static PlayingAs host = PlayingAs.NULL, client = PlayingAs.NULL;
	
	public GameObject ChooseText, ManText, WormText;
	
	private WormController _wc;

	// Use this for initialization
	void Start () {
		_wc = GameObject.FindWithTag("Worm").GetComponent<WormController>();
	}
	
	public void SelectMan()
	{
		if (Network.isServer)
		{
			networkView.RPC("SetPlayers", RPCMode.AllBuffered, false);
		}
		else
		{
			networkView.RPC("SetPlayers", RPCMode.AllBuffered, true);
		}
	}
	
	public void SelectWorm()
	{
		if (Network.isServer)
		{
			networkView.RPC("SetPlayers", RPCMode.AllBuffered, true);
		}
		else
		{
			networkView.RPC("SetPlayers", RPCMode.AllBuffered, false);
		}
	}
	
	void DestroyText()
	{
		if (ChooseText != null) Destroy(ChooseText);
		if (WormText != null) Destroy (WormText);
		if (ManText != null) Destroy(ManText);
	}
	
	[RPC]
	void SetPlayers(bool hostIsWorm)  // set the players on each computer
	{
		if (hostIsWorm)
		{
			host = PlayingAs.WORM;
			client = PlayingAs.MAN;
		}
		else
		{
			host = PlayingAs.MAN;
			client = PlayingAs.WORM;
		}
		
		_wc.enabled = true;
		DestroyText();
	}
}
