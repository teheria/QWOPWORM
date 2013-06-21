using UnityEngine;
using System.Collections;

public class OnMouseOverHighlight : MonoBehaviour {

	public Color Highlight = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	private Color _initialColor;
	
	// Use this for initialization
	void Start () {
		_initialColor = renderer.material.color;
	}
	
	void OnMouseOver()
	{
		renderer.material.color = Highlight;
	}
	
	void OnMouseExit()
	{
		renderer.material.color = _initialColor;
	}
}
