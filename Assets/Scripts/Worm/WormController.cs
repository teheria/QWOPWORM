using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**********************************************************************
 * 
 * Class WormController
 * 
 * Implentation of the controller for the worm player
 * 
 *********************************************************************/
public class WormController : MonoBehaviour {
	
	private Transform _transform;
	private Animation _animation;
	private AnimationClip _fullAnimation;
	
	private Dictionary<string, string> _inputAnimationKeys;
	private string _currentKey;
	private int _index = 0;
	private const float _speed = 10.0f;
	private const float _distance = 1.0f;
	
	void Awake() {
		_transform = transform;
		_animation = animation;
		_fullAnimation = animation.clip;
		
		_inputAnimationKeys = new Dictionary<string, string>();
		
		_inputAnimationKeys.Add("WormW", "moveW");
		_inputAnimationKeys.Add("WormO", "moveO");
		_inputAnimationKeys.Add("WormR", "moveR");
		_inputAnimationKeys.Add("WormM", "moveM");
		
		_currentKey = "WormW";
	}
	
	void Start() {
		_animation.AddClip(_fullAnimation, "moveW", -1, 15, false);
		_animation.AddClip(_fullAnimation, "moveO", 15, 30, false);
		_animation.AddClip(_fullAnimation, "moveR", 30, 45, false);
		_animation.AddClip(_fullAnimation, "moveM", 45, 59, false);
		_animation.AddClip(_fullAnimation, "reset", 0, 0, false);
		
	}
	
	void Update() {		
		
		if (Input.GetButtonDown(_currentKey)) {
			_animation.Play(_inputAnimationKeys[_currentKey]);
			_animation[_inputAnimationKeys[_currentKey]].speed = _speed;
			++_index;
			GetNextAnimationKey();
			_transform.position += (_transform.forward * _distance);
		} else if (Input.anyKeyDown) {
			_animation.Stop();
			_index = 0;
			gameObject.SampleAnimation(_fullAnimation, 0);
			_currentKey = "WormW";
			_transform.position -= (_transform.forward * _distance);
		}
	}
	
	private void GetNextAnimationKey() {
		
		if (_index > 3) {
			_index = 0;
		}
		
		switch (_index) {
		case 0:
			_currentKey = "WormW";
			break;
		case 1:
			_currentKey = "WormO";
			break;
		case 2:
			_currentKey = "WormR";
			break;
		case 3:
			_currentKey = "WormM";
			break;
		}
	}
}
