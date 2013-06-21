using UnityEngine;
using System.Collections;

public class SelectMan : MonoBehaviour {
	
	private PlayerManager _pm;
	
	void Start()
	{
		_pm = GameObject.Find ("GameManager").GetComponent<PlayerManager>();
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_pm.SelectMan();
		}
	}
}
