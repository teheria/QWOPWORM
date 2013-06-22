using UnityEngine;
using System.Collections;

public class ScoreManager : Singleton<ScoreManager> {
	
	public GUIStyle guiStyle;
	
	private int _manScore = 0;
	private int _wormScore = 0;
	
	public int ManScore {
		get { return _manScore; }
		set { _manScore = value; }
	}
	
	public int WormScore {
		get { return _wormScore; }
		set { _wormScore = value; }
	}
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		stream.Serialize(ref _manScore);
		stream.Serialize(ref _wormScore);
	}
	
	void OnGUI() {
		
		// Hacky way to keep GUI with aspect ratio
		// This will stretch things a bit
		float screenWith = Screen.width / 1024.0f;
		float screenHeight = Screen.height / 768.0f;
		
		Matrix4x4 orgMatrix = GUI.matrix;
		
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,
			new Vector3(screenWith, screenHeight, 1.0f));

		GUI.Label(new Rect(20, 20, 150, 24), "Man Score: " + _manScore, guiStyle);
		GUI.Label(new Rect(834, 20, 150, 24), "Worm Score: " + _wormScore, guiStyle);
		
		GUI.matrix = orgMatrix;
	}
}
